using DemoNetApi.Application.Interfaces.Repository;
using DemoNetApi.Application.Users;
using DemoNetApi.Domain.Entities;
using DemoNetApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetApi.Infrastructure.Repositories
{
    public class UserRepository :  IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginRespone> LoginUserAsync(LoginUser user)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(x => x.UserEmail == user.UserEmail);
            if (getUser == null)
                return new LoginRespone(false, "User not found", null); // Trả về đủ các tham số cần thiết

            bool checkPassword = BCrypt.Net.BCrypt.Verify(user.UserPassword, getUser.UserPassword);
            if (checkPassword)
                return new LoginRespone(true, "Login Success", GenerateJWTToken(getUser));
            else
                return new LoginRespone(false, "Invalid", null);
        }

        private string GenerateJWTToken(User getUser)
        {
            var securetyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(securetyKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, getUser.UserId.ToString()),
                new Claim(ClaimTypes.Name, getUser.UserName),
                new Claim(ClaimTypes.Email, getUser.UserEmail)
            };
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"], 
                _configuration["Jwt:Audience"], 
                claims: userClaims, 
                expires: DateTime.Now.AddMinutes(120), 
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RegisterRespone> RegisterUserAsync(RegisterUser user)
        {
            var getUser = await _context.Users.FirstOrDefaultAsync(x => x.UserEmail == user.UserEmail);
            if (getUser != null)
                return new RegisterRespone(false, "User already exists");
            _context.Users.Add(new User
            {
                UserName = user.UserName,
                UserEmail = user.UserEmail,
                UserPassword = BCrypt.Net.BCrypt.HashPassword(user.UserPassword)
            });
            await _context.SaveChangesAsync();
            return new RegisterRespone(true, "Register Success");

        }
    }
}

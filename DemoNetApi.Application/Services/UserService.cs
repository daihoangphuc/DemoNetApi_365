using DemoNetApi.Application.Interfaces.Repository;
using DemoNetApi.Application.Interfaces.Service;
using DemoNetApi.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<LoginRespone> LoginUserAsync(LoginUser user)
        {
            return await _userRepository.LoginUserAsync(user);
        }

        public async Task<RegisterRespone> RegisterUserAsync(RegisterUser user)
        {
            return await _userRepository.RegisterUserAsync(user);
        }
    }
}

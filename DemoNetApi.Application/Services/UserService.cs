using AutoMapper;
using DemoNetApi.Application.Interfaces.Repository;
using DemoNetApi.Application.Interfaces.Service;
using DemoNetApi.Application.Users;
using DemoNetApi.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;


namespace DemoNetApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LoginRespone> LoginUserAsyncService(LoginUser user)
        {
            var userlogin = _mapper.Map<LoginUser>(user);

            _logger.LogInformation($"Currently logged log in user: {userlogin.UserEmail}", userlogin.UserEmail);

            return await _userRepository.LoginUserAsync(userlogin);
        }

        public async Task<RegisterRespone> RegisterUserAsyncService(RegisterUser user)
        {
            var registerUser = _mapper.Map<RegisterUser>(user);

            _logger.LogInformation($"Currently registered user: {registerUser.UserEmail}", registerUser.UserEmail);

            return await _userRepository.RegisterUserAsync(registerUser);
        }
        public Task<User> GetUserByIdAsyncService(int userId)
        {
            var user = _userRepository.GetUserByIdAsync(userId);
            if(user == null )
            {
                _logger.LogError($"User with id: {userId} not found", userId);
            }
            return user;
        }

        public async Task DeleteUserAsyncService(int id)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    _logger.LogError($"User with id: {id} not found", id);
                }
                _userRepository.DeleteUser(user);
                await _userRepository.SaveChangeAsync();
            }catch (Exception ex)
            {
                _logger.LogError(ex, $"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> GetAllUserAsyncService()
        {
            var users = await _userRepository.GetAllUserAsync();
            if (users == null)
            {
                _logger.LogInformation($"No user found!");
            }
            return users;
        }
    }
}

using AutoMapper;
using DemoNetApi.Application.Interfaces.Repository;
using DemoNetApi.Application.Interfaces.Service;
using DemoNetApi.Application.Users;
using DemoNetApi.Domain.Entities;
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
    }
}

using AutoMapper;
using DemoNetApi.Application.Interfaces.Repository;
using DemoNetApi.Application.Interfaces.Service;
using DemoNetApi.Application.Users;
using Microsoft.Extensions.Logging;


namespace DemoNetApi.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<LoginRespone> LoginUserAsyncService(LoginUser user)
        {

            var userlogin = _mapper.Map<LoginUser>(user);
            return await _userRepository.LoginUserAsync(userlogin);
        }

        public async Task<RegisterRespone> RegisterUserAsyncService(RegisterUser user)
        {
            var registerUser = _mapper.Map<RegisterUser>(user);
            return await _userRepository.RegisterUserAsync(registerUser);
        }
    }
}

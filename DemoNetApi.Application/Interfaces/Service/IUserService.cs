using DemoNetApi.Application.Users;

namespace DemoNetApi.Application.Interfaces.Service
{
    public interface IUserService
    {
        Task<RegisterRespone> RegisterUserAsyncService(RegisterUser user);
        Task<LoginRespone> LoginUserAsyncService(LoginUser user);
    }
}

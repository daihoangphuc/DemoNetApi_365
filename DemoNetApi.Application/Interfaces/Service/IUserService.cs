using DemoNetApi.Application.Users;
using DemoNetApi.Domain.Entities;

namespace DemoNetApi.Application.Interfaces.Service
{
    public interface IUserService
    {
        Task<RegisterRespone> RegisterUserAsyncService(RegisterUser user);
        Task<LoginRespone> LoginUserAsyncService(LoginUser user);
        Task<User> GetUserByIdAsyncService(int userId);
        Task<IEnumerable<User>> GetAllUserAsyncService();
        Task DeleteUserAsyncService(int id);
    }
}

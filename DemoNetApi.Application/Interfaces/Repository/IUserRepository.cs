using DemoNetApi.Application.Users;
using DemoNetApi.Domain.Entities;
using System.Collections.Generic;


namespace DemoNetApi.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<RegisterRespone> RegisterUserAsync(RegisterUser user);
        Task<LoginRespone> LoginUserAsync(LoginUser user);
        Task<User> GetUserByIdAsync(int userId);
        Task<IReadOnlyList<User>> GetAllUserAsync();
        void DeleteUser(User user);
        Task SaveChangeAsync();
    }
}

using DemoNetApi.Application.Users;


namespace DemoNetApi.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<RegisterRespone> RegisterUserAsync(RegisterUser user);
        Task<LoginRespone> LoginUserAsync(LoginUser user);
    }
}

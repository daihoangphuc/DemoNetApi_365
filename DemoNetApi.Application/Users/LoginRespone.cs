

namespace DemoNetApi.Application.Users
{
    public record LoginRespone(bool Success, string Message = null!, string Token=null!);
}

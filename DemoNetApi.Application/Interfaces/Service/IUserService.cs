using DemoNetApi.Application.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetApi.Application.Interfaces.Service
{
    public interface IUserService
    {
        Task<RegisterRespone> RegisterUserAsync(RegisterUser user);
        Task<LoginRespone> LoginUserAsync(LoginUser user);
    }
}

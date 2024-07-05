using DemoNetApi.Application.Interfaces.Service;
using DemoNetApi.Application.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }   

        [HttpPost("login")]
        public async Task<ActionResult<LoginRespone>> LogUserIn(LoginUser loginUser)
        {
           var result = await userService.LoginUserAsync(loginUser);
           return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterRespone>> RegisterUser(RegisterUser registerUser)
        {
            var result = await userService.RegisterUserAsync(registerUser);
            return Ok(result);
        }
    }
}

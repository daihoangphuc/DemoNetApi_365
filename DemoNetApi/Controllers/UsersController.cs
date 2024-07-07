using DemoNetApi.Application.Interfaces.Service;
using DemoNetApi.Application.Services;
using DemoNetApi.Application.Users;
using DemoNetApi.Domain.Entities;
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
        public async Task<ActionResult<LoginRespone>> LogUserIn([FromBody] LoginUser loginUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await userService.LoginUserAsyncService(loginUser);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterRespone>> RegisterUser([FromBody] RegisterUser registerUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await userService.RegisterUserAsyncService(registerUser);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await userService.GetAllUserAsyncService();

            if (users == null || !users.Any())
            {
                return Ok(new { message = "Khong co user nao!" });
            }

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await userService.GetUserByIdAsyncService(id);

            if (user == null)
            {
                return NotFound(new { message = $"Khong tim thay user co Id la {id}"});
            }

            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await userService.DeleteUserAsyncService(id);

                return Ok(new { message = "Xoa user thanh cong!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}

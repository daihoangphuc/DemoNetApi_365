using System.ComponentModel.DataAnnotations;


namespace DemoNetApi.Application.Users
{
    public class LoginUser
    {
        [Required, EmailAddress]
        public string UserEmail { get; set; } = string.Empty;
        [Required]
        public string UserPassword { get; set; } = string.Empty;
    }
}

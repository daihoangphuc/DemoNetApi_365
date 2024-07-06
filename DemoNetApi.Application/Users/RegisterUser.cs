using System.ComponentModel.DataAnnotations;


namespace DemoNetApi.Application.Users
{
    public class RegisterUser
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string UserEmail { get; set; } = string.Empty;
        [Required]
        public string UserPassword { get; set; } = string.Empty;
        [Required, Compare(nameof(UserPassword))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

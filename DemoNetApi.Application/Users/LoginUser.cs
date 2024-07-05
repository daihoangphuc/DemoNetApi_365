using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

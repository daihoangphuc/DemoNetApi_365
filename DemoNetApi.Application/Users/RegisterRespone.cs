using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNetApi.Application.Users
{
    public record RegisterRespone(bool Success, string Message = null!);

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_API.Core.DTOs
{
    public record LoginUserDto
    {
        
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

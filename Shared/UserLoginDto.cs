using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record UserLoginDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

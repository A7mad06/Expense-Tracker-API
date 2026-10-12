using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public record UserRegisterDto
    {
        public string FullName { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string DisplayName { get; set; }
    }
}

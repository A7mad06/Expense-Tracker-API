using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class JwtOptions
    {
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int DurationInDays { get; set; }
    }
}

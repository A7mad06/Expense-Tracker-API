using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Abstraction
{
    public interface IAuthenticationServices
    {
        public Task<UserResultDto> RegisterAsync(UserRegisterDto userRegisterDto);
        public Task<UserResultDto> LoginAsync(UserLoginDto userLoginDto);
    }
}

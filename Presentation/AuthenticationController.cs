using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController(IServiceManager serviceManager): ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult<UserResultDto>> Login(UserLoginDto userLoginDto)
        {
            var result = await serviceManager.AuthenticationServices.LoginAsync(userLoginDto);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserRegisterDto>> Register(UserRegisterDto registerDto)
        {
            var result = await serviceManager.AuthenticationServices.RegisterAsync(registerDto);
            return Ok(result);
        }
    }
}

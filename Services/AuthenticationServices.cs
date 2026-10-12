using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Abstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ValidationException = Domain.Exceptions.ValidationException;

namespace Services
{
    public class AuthenticationServices(IConfiguration configuration,UserManager<User> userManager,IOptions<JwtOptions> jwtOptions) : IAuthenticationServices
    {
        public async Task<UserResultDto> LoginAsync(UserLoginDto userLoginDto)
        {
            var user = await userManager.FindByEmailAsync(userLoginDto.Email);
            if (user == null) throw new UnAuthorizedException("Email doesn't exist");
            var result = await userManager.CheckPasswordAsync(user, userLoginDto.Password);
            if (!result) throw new UnAuthorizedException("Password isn't correct");
            return new UserResultDto
            {
                Email = user.Email,
                Name = user.DisplayName,
                Token = await CreateTokenAsync(user)
            };
        }

        public async Task<UserResultDto> RegisterAsync(UserRegisterDto userRegisterDto)
        {
            if(userRegisterDto.Email == null || userRegisterDto.Password == null || userRegisterDto.FullName == null)
            {
                throw new ArgumentNullException("All fields are required");
            }
            var user = new User
            {
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.FullName,
                PhoneNumber = userRegisterDto.PhoneNumber,
                DisplayName = userRegisterDto.DisplayName
            };
            var result = await userManager.CreateAsync(user,userRegisterDto.Password);
            if (!result.Succeeded){
                var errors = result.Errors.Select(e => e.Description).ToList();
                throw new ValidationException(errors);
            }
            return new UserResultDto
            {
                Name=user.DisplayName,
                Email=user.Email,
                Token = await CreateTokenAsync(user)
            };
        }

        private async Task<string> CreateTokenAsync(User user)
        {
            var jwtoptions = jwtOptions.Value;
            var AuthClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.Name,user.DisplayName!)
            };
            var roles = await userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
                AuthClaims.Add(new Claim(ClaimTypes.Role, role));
            }


            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey));
            var SigningCred = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(
                audience: jwtoptions.Audience,
                issuer: jwtoptions.Issuer,
                claims: AuthClaims,
                expires: DateTime.UtcNow.AddDays(jwtoptions.DurationInDays),
                signingCredentials: SigningCred
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}

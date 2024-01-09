using Blog.Business.Dtos.AuthDtos;
using Blog.Business.ExternalServices.Interfaces;
using Blog.Core.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.ExternalServices.Implements
{
    public class TokenService : ITokenService
    {
        IConfiguration _configuration { get; }
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDto CreateToken(AppUser user)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.GivenName, user.UsernameOrEmail));
            claims.Add(new Claim("Test", user.Birthday.ToString()));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            DateTime expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration.GetSection("jet")?["ExpirenMin"]));
            JwtSecurityToken jwt = new JwtSecurityToken(_configuration["Jwt:Audience"],
                _configuration["Jwt:Issuer"],
                claims,
                DateTime.UtcNow,
                expires,
                cred);
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.WriteToken(jwt);

            TokenDto dto = new TokenDto();
            dto.Token = token;

            return new TokenDto
            {
                Expires = expires,
                Token = token,
            };
        }
    }
}

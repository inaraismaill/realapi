using Blog.Business.Dtos.AuthDtos;
using Blog.Business.Exceptions.Auth;
using Blog.Business.Exceptions.Common;
using Blog.Business.ExternalServices.Interfaces;
using Blog.Business.Services.Interfaces;
using Blog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<AppUser> _usermanager { get; }
        ITokenService _tokenService { get; }
        public AuthService(UserManager<AppUser> usermanager, ITokenService tokenService)
        {
            _usermanager = usermanager;
            _tokenService = tokenService;
        }

        public async Task<TokenDto> Login(LoginDto dto)
        {
            AppUser? user = null;
            if(dto.UsernameOrEmail.Contains("@"))
            {
                user=await _usermanager.FindByEmailAsync(dto.UsernameOrEmail);
            }
            else
            {
                user = await _usermanager.FindByNameAsync(dto.UsernameOrEmail);
            }
            if (user == null) throw new UernameorPasswordException();
            var result =await _usermanager.CheckPasswordAsync(user,dto.Password);
            if(!result) throw new UernameorPasswordException();
            return _tokenService.CreateToken(user);
        }

       
    }
}

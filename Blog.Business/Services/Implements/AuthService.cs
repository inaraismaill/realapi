using Blog.Business.Dtos.AuthDtos;
using Blog.Business.Exceptions.Auth;
using Blog.Business.ExternalServices.Interfaces;
using Blog.Business.Services.Interfaces;
using Blog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Implements
{
    public class AuthService : IAuthService
    {
        UserManager<AppUser> _userManager { get; }
        ITokenService _tokenService { get; }

        public AuthService(UserManager<AppUser> userManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<TokenDto> Login(LoginDto dto)
        {
            AppUser? user = null;
            if (dto.UsernameOrEmail.Contains("@"))
            {
                user = await _userManager.FindByEmailAsync(dto.UsernameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(dto.UsernameOrEmail);
            }
            if (user == null) throw new UernameorPasswordException();
            var result = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!result) throw new UernameorPasswordException();
            return _tokenService.CreateToken(user);
        }
    }
}

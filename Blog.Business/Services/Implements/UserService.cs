using AutoMapper;
<<<<<<< HEAD
using Blog.Business.Dtos.AppUser;
using Blog.Business.Exceptions.AppUser;
using Blog.Business.Services.Interfaces;
using Blog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
=======
using Blog.Business.Dtos.AuthDtos;
using Blog.Business.Exceptions.Auth;
using Blog.Business.Exceptions.Common;
using Blog.Business.ExternalServices.Implements;
using Blog.Business.ExternalServices.Interfaces;
using Blog.Business.Services.Interfaces;
using Blog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
>>>>>>> 5d78b326896165b775f4d0574c9e183cd6ec5cc1
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Implements
{
    public class UserService : IUserService
    {
<<<<<<< HEAD
        UserManager<AppUser> _userManager { get; }
        IMapper _mapper { get; }

        public UserService(UserManager<AppUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task CreateAsync(RegisterDto dto)
        {
            AppUser user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new();
=======
        UserManager<AppUser> _usermanager { get; }
        ITokenService _tokenService { get; }
        IMapper _mapper { get; }
        public UserService(IMapper mapper, UserManager<AppUser> usermanager, ITokenService tokenService)
        {
            _mapper = mapper;
            _usermanager = usermanager;
            _tokenService = tokenService;
        }
        public async Task<TokenDto> LoginAsync(LoginDto dto)
        {
            var user = await _usermanager.Users.SingleOrDefaultAsync(x => x.UserName == dto.UsernameOrEmail || x.Email == dto.UsernameOrEmail);
            if (user == null) throw new UernameorPasswordException();
            var result = await _usermanager.CheckPasswordAsync(user, dto.Password);
            if (!result) throw new UernameorPasswordException();
            return _tokenService.CreateToken(user);
        }
        public async Task RegisterAsync(RegisterDto dto)
        {
            var user = _mapper.Map<AppUser>(dto);
            var result = await _usermanager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
>>>>>>> 5d78b326896165b775f4d0574c9e183cd6ec5cc1
                foreach (var item in result.Errors)
                {
                    sb.Append(item.Description + " ");
                }
<<<<<<< HEAD
                throw new AppUserCreatedFailledException(sb.ToString().TrimEnd());
=======
                throw new RegisterFailedException(sb.ToString().TrimEnd());
>>>>>>> 5d78b326896165b775f4d0574c9e183cd6ec5cc1
            }
        }
    }
}

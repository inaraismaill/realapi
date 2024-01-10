<<<<<<< HEAD
﻿using Blog.Business.Dtos.AppUser;
=======
﻿using Blog.Business.Dtos.AuthDtos;
>>>>>>> 5d78b326896165b775f4d0574c9e183cd6ec5cc1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Interfaces
{
    public interface IUserService
    {
<<<<<<< HEAD
        public Task CreateAsync(RegisterDto dto);
=======
        public Task RegisterAsync(RegisterDto dto);
        public Task<TokenDto> LoginAsync(LoginDto dto);
>>>>>>> 5d78b326896165b775f4d0574c9e183cd6ec5cc1
    }
}

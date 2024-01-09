using Blog.Business.Dtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Interfaces
{
    public interface IAuthService
    {
        Task<TokenDto> Login(LoginDto dto);
    }
}

using Blog.Business.Dtos.AuthDtos;
using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.ExternalServices.Interfaces
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser user);

    }
}

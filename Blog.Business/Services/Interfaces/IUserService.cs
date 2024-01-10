using Blog.Business.Dtos.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateAsync(RegisterDto dto);
    }
}

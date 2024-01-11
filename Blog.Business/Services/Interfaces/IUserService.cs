using Blog.Business.Dtos.AppUser;

namespace Blog.Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task CreateAsync(RegisterDto dto);
    }
}

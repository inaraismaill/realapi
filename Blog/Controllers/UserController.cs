using Blog.Business.Dtos.AppUser;
using Blog.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService { get; }

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterDto dto)
        {
            await _userService.CreateAsync(dto);
            return Ok();
        }
    }
}

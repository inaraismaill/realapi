using Blog.Business.Dtos.AuthDtos;
using Blog.Business.ExternalServices.Interfaces;
using Blog.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IUserService _userService { get; }
        IEmailService _emailServices { get; }
        public AuthsController(IUserService userService, IEmailService emailServices)
        {
            _userService = userService;
            _emailServices = emailServices;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _userService.RegisterAsync(dto);
            _emailServices.Send(dto.Email, "Welcome", "Hellooooo");
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await _userService.LoginAsync(dto));
        }

    }
}

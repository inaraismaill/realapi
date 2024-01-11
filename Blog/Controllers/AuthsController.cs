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
        IAuthService _service { get; }

        public AuthsController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            return Ok(await _service.Login(dto));
        }
    }
}

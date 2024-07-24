using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TwitterApi.Bussines.Dtos.AppUserDtos;
using TwitterApi.Bussines.Services.Interfaces;

namespace TwitterApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _auth { get; }
        public AuthsController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("LoginAsync")]
        public async Task<IActionResult> LoginAsync(LoginDto dto)
        {
            return Ok(await _auth.LoginAsync(dto));
        }

        [HttpPost("ForgotPasswordAsync")]
        public async Task<IActionResult> ForgotPasswordAsync(PasswordRessetDto dto)
        {
            await _auth.ForgotPassworAsync(dto.Email);
            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterApi.Bussines.Dtos.AppUserDtos;
using TwitterApi.Bussines.Dtos.UserDtos;
using TwitterApi.Bussines.Helpers;
using TwitterApi.Bussines.Services.Interfaces;

namespace TwitterApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _user { get; }
        public UsersController(IUserService user)
        {
            _user = user;
        }

        [Authorize]
        [HttpPost("ChagePasswordAsync")]
        public async Task<IActionResult> ChagePasswordAsync(ChangePassworDto dto)
        {

            await _user.ChangePassworAsync(dto, User);
            return Ok();
        }

        [HttpGet("EmailConfirmedAsync/{userId}/{token}")]
        public async Task<IActionResult> EmailConfirmedAsync(string userId, string token)
        {

            await _user.EmailConfirmedAsync(userId, token);
            return Ok();
        }

        [HttpPost("RegisterAsync")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto registerDto)
        {

            await _user.CreateUserAsync(registerDto);
            return Ok();
        }

        [HttpPost("ResetPasswordAsync")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] UpdatePasswordDto update)
        {
            await _user.UpdatePasswordAsync(update);
            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> UserRemoveAsync()
        {
            await _user.RemoveUserAsync(User, HttpContext.GetUserToken());
            return Ok();
        }
    }
}

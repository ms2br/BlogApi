using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterApi.Bussines.Dtos.AppUserDtos;
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
            try
            {
                await _user.ChangePassworAsync(dto, User);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("EmailConfirmedAsync/{userId}/{token}")]
        public async Task<IActionResult> EmailConfirmedAsync(string userId, string token)
        {
            try
            {
                await _user.EmailConfirmedAsync(userId, token);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("RegisterAsync")]
        public async Task<IActionResult> RegisterAsync([FromForm] RegisterDto registerDto)
        {
            try
            {
                await _user.CreateUserAsync(registerDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("ResetPasswordAsync")]
        public async Task<IActionResult> ResetPasswordAsync([FromBody] UpdatePasswordDto update)
        {
            try
            {
                await _user.UpdatePasswordAsync(update);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterApi.Bussines.Dtos.PostReactionDtos;
using TwitterApi.Bussines.Services.Interfaces;
using TwitterApi.Core.Entities;

namespace TwitterApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostReactionsController : ControllerBase
    {
        IPostReactionService _service { get; }

        public PostReactionsController(IPostReactionService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var item = await _service.GetAllAsync<PRDetailDto>("Post","AppUser");
                return Ok(item);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("[action]/{postId?}")]
        public async Task<IActionResult> GetByIdAsync(int? postId)
        {
            try
            {
                var item = await _service.GetByIdAsync<PRDetailDto>(postId, "AppUser", "Post");
                return Ok(item);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAsync(PRCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("[action]/{postId?}")]
        public async Task<IActionResult> UpdateAsync(int? postId, PRUpdateDto dto)
        {
            try
            {
                await _service.UpdateAsync(postId, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("[action]/{postId?}")]
        public async Task<IActionResult> RemoveAsync(int? postId)
        {
            try
            {
                await _service.RemoveAsync(postId);
                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("[action]/{postId?}")]
        public async Task<IActionResult> SoftRemoveAsync(int? postId)
        {
            try
            {
                await _service.SoftRemoveAsync(postId);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

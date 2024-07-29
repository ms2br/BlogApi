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
            return Ok(await _service.GetAllAsync<PRDetailDto>("Post", "AppUser"));
        }

        [HttpGet("[action]/{postId?}")]
        public async Task<IActionResult> GetByIdAsync(int? postId)
        {
            return Ok(await _service.GetByIdAsync<PRDetailDto>(postId, "AppUser", "Post"));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAsync(PRCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("[action]/{postId?}")]
        public async Task<IActionResult> UpdateAsync(int? postId, PRUpdateDto dto)
        {

            await _service.UpdateAsync(postId, dto);
            return Ok();
        }

        [HttpDelete("[action]/{postId?}")]
        public async Task<IActionResult> RemoveAsync(int? postId)
        {
            await _service.RemoveAsync(postId);
            return Ok();
        }

        [HttpDelete("[action]/{postId?}")]
        public async Task<IActionResult> SoftRemoveAsync(int? postId)
        {
            await _service.SoftRemoveAsync(postId);
            return Ok();
        }
    }
}

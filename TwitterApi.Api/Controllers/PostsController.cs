using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Bussines.Services.Implements;
using TwitterApi.Bussines.Services.Interfaces;

namespace TwitterApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        IPostService _service { get; }

        public PostsController(IPostService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync<PostDetailDto>("Files", "Topics.Topic", "Topics", "AppUser"));
        }

        [HttpGet("[action]/{id?}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            return Ok(await _service.GetByIdAsync<PostDetailDto>(id, "Files", "Topics.Topic", "Topics", "AppUser"));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAsync([FromForm] PostCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("[action]/{id?}")]
        public async Task<IActionResult> UpdateAsync(int? id, [FromForm] PostUpdateDto update)
        {

            await _service.UpdateAsync(id, update, "Files", "Topics.Topic", "AppUser");
            return Ok();
        }

        [HttpPatch("[action]/{blogId?}/{fileId?}")]
        public async Task<IActionResult> UpdateImgAsync(int? blogId,int? fileId,[FromForm] FileUpdateDto file)
        {
            await _service.UpdateImgFilesAsync(blogId, fileId, file, "Files");
            return Ok();
        }

        [HttpDelete("[action]/{id?}")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {

            await _service.RemoveAsync(id, "Files", "Topics.Topic");
            return Ok();
        }

        [HttpDelete("[action]/{blogId?}/{fileId?}")]
        public async Task<IActionResult> RemoveImgAsync(int? blogId, int? fileId)
        {

            await _service.RemoveImgFilesAsync(blogId, fileId, "Files");
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> SoftRemoveAsync(int? id)
        {
            await _service.SoftRemoveAsync(id, "Files");
            return Ok();
        }
    }
}

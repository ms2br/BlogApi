using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterApi.Bussines.Dtos.BlogDto;
using TwitterApi.Bussines.Services.Interfaces;

namespace TwitterApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogsController : ControllerBase
    {
        IBlogService _service { get; }

        public BlogsController(IBlogService service)
        {
            _service = service;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var item = await _service.GetAllAsync<BlogDetailDto>("Files", "BlogTopics");
                await _service.Test();
                return Ok(item);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> AddAsync([FromForm] BlogCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("RemoveAsync")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

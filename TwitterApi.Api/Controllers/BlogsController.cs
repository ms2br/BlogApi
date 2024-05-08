using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterApi.Bussines.Dtos.BlogDtos;
using TwitterApi.Bussines.Dtos.FileDtos;
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var item = await _service.GetAllAsync<BlogDetailDto>("Files", "Topics.Topic", "Topics","AppUser");
                return Ok(item);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("[action]/{id?}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            try
            {
                var item = await _service.GetByIdAsync<BlogDetailDto>(id,"Files", "Topics.Topic", "Topics", "AppUser");
                return Ok(item);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAsync([FromForm] BlogCreateDto dto)
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

        [HttpPut("[action]/{id?}")]
        public async Task<IActionResult> UpdateAsync(int? id, [FromForm] BlogUpdateDto update)
        {
            try
            {
                await _service.UpdateAsync(id, update, "Files", "Topics.Topic" ,"AppUser");
                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPatch("[action]/{blogId?}/{fileId?}")]
        public async Task<IActionResult> UpdateImgAsync(int? blogId,int? fileId,[FromForm] FileUpdateDto file)
        {
            try
            {
               await _service.UpdateImgFilesAsync(blogId,fileId,file,"Files");
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("[action]/{id?}")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {
            try
            {
                await _service.RemoveAsync(id, "Files","Topics.Topic");
                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("[action]/{blogId?}/{fileId?}")]
        public async Task<IActionResult> RemoveImgAsync(int? blogId, int? fileId)
        {
            try
            {
                await _service.RemoveImgFilesAsync(blogId, fileId, "Files");
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> SoftRemoveAsync(int? id)
        {
            try
            {
                await _service.SoftRemoveAsync(id,"Files");
                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Bussines.Services.Interfaces;

namespace TwitterApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TopicsController : ControllerBase
    {
        ITopicService _service { get; }
        public TopicsController(ITopicService service)
        {
            _service = service;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _service.GetAllAsync<TopicDetailDto>());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            try
            {
                return Ok(await _service.GetByIdAsync<TopicDetailDto>(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost("CreateTopicAsync")]
        public async Task<IActionResult> CreateTopicAsync(TopicCreateDto dto)
        {
            try
            {
                await _service.CreateAsync(dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("UpdateTopic")]
        public async Task<IActionResult> Task(int? id, TopicUpdateDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
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
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("SoftRemoveAsync")]
        public async Task<IActionResult> SoftRemoveAsync(int? id)
        {
            try
            {
                await _service.SoftRemoveAsync(id);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}

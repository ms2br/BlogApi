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
            return Ok(await _service.GetAllAsync<TopicDetailDto>());
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            return Ok(await _service.GetByIdAsync<TopicDetailDto>(id));

        }

        [HttpPost("CreateTopicAsync")]
        public async Task<IActionResult> CreateTopicAsync(TopicCreateDto dto)
        {

            await _service.CreateAsync(dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("UpdateTopic")]
        public async Task<IActionResult> Task(int? id, TopicUpdateDto dto)
        {

            await _service.UpdateAsync(id, dto);
            return Ok();
        }

        [HttpDelete("RemoveAsync")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {

            await _service.RemoveAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("SoftRemoveAsync")]
        public async Task<IActionResult> SoftRemoveAsync(int? id)
        {
            await _service.SoftRemoveAsync(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}

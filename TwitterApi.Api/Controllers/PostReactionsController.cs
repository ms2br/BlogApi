using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterApi.Bussines.Dtos.PostReactionDtos;
using TwitterApi.Bussines.Services.Interfaces;

namespace TwitterApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostReactionsController : ControllerBase
    {
        IPostReactionService _service { get; }

        public PostReactionsController(IPostReactionService service)
        {
            _service = service;
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
    }
}

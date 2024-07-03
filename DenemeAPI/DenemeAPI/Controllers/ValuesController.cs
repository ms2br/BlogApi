using DenemeAPI.Context;
using DenemeAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DenemeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public MyDbContext prop { get; set; }

        public ValuesController(MyDbContext context)
        {
            prop = context;
        }

        [HttpPost]
        public async Task<IActionResult> Index(Student student)
        {
            prop.Students.Add(student);
            await prop.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> IndexAsas(Teacher student)
        {
            prop.Teachers.Add(student);
            await prop.SaveChangesAsync();
            return Ok();
        }
    }
}

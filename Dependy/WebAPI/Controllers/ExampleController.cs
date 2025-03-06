using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebAPI.Controllers
{
    [ApiController]
    public class ExampleController : ControllerBase
    {
        [Route("/hi")]
        [HttpGet]
        public IActionResult Welcome()
        {
            Log.Information("This is a verbose message.hiiiiiiiiiiiiiiiiiii");
            return Ok(new{ message="Welcome Pappikutti"});
        }
    }
}

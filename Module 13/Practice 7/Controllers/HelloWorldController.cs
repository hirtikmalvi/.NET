using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practice_7.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/hello")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        [ApiVersion("1.0")]
        public IActionResult GetV1()
        {
            return Ok("Hello World");
        }

        [HttpGet]
        [ApiVersion("2.0")]
        public IActionResult GetV2()
        {
            return Ok("Hello World".ToUpper());
        }
    }
}

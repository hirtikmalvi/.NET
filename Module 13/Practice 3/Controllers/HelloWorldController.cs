using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practice_3.Controllers
{
    [Route("practice_1")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        [Route("greet")]
        public ActionResult<string> GetHelloWorld()
        {
            return Ok("Hello, World!");
        }

        [HttpGet]
        [Route("greet/{name}")]
        public ActionResult<string> GetName(string name)
        {
            return $"Hello, {name}!";
        }
    }
}

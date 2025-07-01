using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Practice_3
{
    [ApiController]
    public class FactorialController : ControllerBase
    {
        [HttpGet]
        [Route("factorial")]
        public ActionResult<int> GetFactorial(int number)
        {
            if (number >= 0)
            {
                int result = 1;
                if (number == 0)
                {
                    return Ok(result);
                }

                for (int i = 1; i <= number; i++)
                {
                    result = result * i;
                }
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

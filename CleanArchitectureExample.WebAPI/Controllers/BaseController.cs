using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestingOnly.Application.Orchestration;

namespace TestingOnly.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        public async Task<IActionResult> ReturnRequestResult(RequestResult requestResult)
        {
            if (requestResult.Success)
            {
                return Ok(requestResult);
            }
            else
            {
                return BadRequest(requestResult);
            }
        }
    }
}
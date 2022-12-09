using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestingOnly.Application.Orchestration;
using TestingOnly.Domain.RequestHandlers.AuthorsHandlers.Commands.AddAuthor;

namespace TestingOnly.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private readonly IOrchestrator _orquestrator;

        public AuthorController(IOrchestrator orquestrator)
        {
            _orquestrator = orquestrator;
        }

        [HttpPost]
        [Route("Add/v1")]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorCommand command)
        {
            RequestResult requestResult = await _orquestrator.SendCommand(command);
            return await ReturnRequestResult(requestResult);
        }
    }
}
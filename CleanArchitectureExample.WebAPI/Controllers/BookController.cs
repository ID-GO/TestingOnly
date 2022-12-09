using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestingOnly.Application.Orchestration;
using TestingOnly.Domain.RequestHandlers.BookHandlers.Commands.AddBook;

namespace TestingOnly.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        private readonly IOrchestrator _orquestrator;

        public BookController(IOrchestrator orquestrator)
        {
            _orquestrator = orquestrator;
        }

        [Route("Add/v1")]
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookCommand command)
        {
            RequestResult requestResult = await _orquestrator.SendCommand(command);
            return await ReturnRequestResult(requestResult);
        }
    }
}
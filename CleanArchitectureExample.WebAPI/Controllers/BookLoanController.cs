using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestingOnly.Application.Orchestration;
using TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Commands.RequestLoan;
using TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Commands.ReturnBook;
using TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Queries;

namespace TestingOnly.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLoanController : BaseController
    {
        private readonly IOrchestrator _orquestrator;

        public BookLoanController(IOrchestrator orquestrator)
        {
            _orquestrator = orquestrator;
        }

        [HttpPost]
        [Route("RequestLoan/v1")]
        public async Task<IActionResult> Loan([FromBody] RequestLoanCommand command)
        {
            RequestResult requestResult = await _orquestrator.SendCommand(command);
            return await ReturnRequestResult(requestResult);
        }

        [HttpPost]
        [Route("ReturnBook/v1")]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnBookCommand command)
        {
            RequestResult requestResult = await _orquestrator.SendCommand(command);
            return await ReturnRequestResult(requestResult);
        }

        [HttpGet]
        [Route("GetAll/v1")]
        public async Task<IActionResult> GetAllLoans()
        {
            RequestResult requestResult = await _orquestrator.SendQuery(new BookLoanGetAllQuery());
            return await ReturnRequestResult(requestResult);
        }
    }
}
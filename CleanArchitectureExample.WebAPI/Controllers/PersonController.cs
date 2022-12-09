using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestingOnly.Application.Orchestration;
using TestingOnly.Domain.RequestHandlers.PersonHandlers.Commands.AddPerson;
using TestingOnly.Domain.RequestHandlers.PersonHandlers.Queries.GetAll;

namespace TestingOnly.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IOrchestrator _orquestrator;

        public PersonController(IOrchestrator orquestrator)
        {
            _orquestrator = orquestrator;
        }

        [Route("Add/v1")]
        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonCommand command)
        {
            RequestResult requestResult = await _orquestrator.SendCommand(command);
            return await ReturnRequestResult(requestResult);
        }

        [Route("GetAll/v1")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _orquestrator.SendQuery(new GetAllPeopleQuery());
            return await ReturnRequestResult(result);
        }
    }
}
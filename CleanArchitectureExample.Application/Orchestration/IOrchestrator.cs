using System.Threading.Tasks;
using MediatR;

namespace TestingOnly.Application.Orchestration
{
    public interface IOrchestrator
    {
        Task<RequestResult> SendCommand<T>(IRequest<T> request);
        Task<RequestResult> SendQuery<T>(IRequest<T> request);
    }
}

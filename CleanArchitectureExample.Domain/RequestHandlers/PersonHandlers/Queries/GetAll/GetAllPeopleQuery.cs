using MediatR;

namespace TestingOnly.Domain.RequestHandlers.PersonHandlers.Queries.GetAll
{
    public class GetAllPeopleQuery:IRequest<GetAllPeopleQueryViewModel>
    {
    }
}

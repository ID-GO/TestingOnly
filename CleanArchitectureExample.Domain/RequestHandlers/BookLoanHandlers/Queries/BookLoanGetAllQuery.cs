using MediatR;

namespace TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Queries
{
    public class BookLoanGetAllQuery: IRequest<BookLoanGetAllQueryResponseViewModel>
    {
    }
}

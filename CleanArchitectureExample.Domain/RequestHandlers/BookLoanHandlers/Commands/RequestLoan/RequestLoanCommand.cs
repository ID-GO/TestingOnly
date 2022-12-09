using MediatR;

namespace TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Commands.RequestLoan
{
    public class RequestLoanCommand: IRequest<RequestLoanCommandResponseViewModel>
    {
        public RequestLoanCommand(string personDocument, string bookId)
        {
            PersonDocument = personDocument;
            BookId = bookId;
        }

        public string PersonDocument { get; private set; }
        public string BookId { get; private set; }
    }
}

using MediatR;

namespace TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Commands.ReturnBook
{
    public class ReturnBookCommand : IRequest<ReturnBookCommandResponseViewModel>
    {
        public ReturnBookCommand(string loanId)
        {
            LoanId = loanId;
        }

        public string LoanId { get; private set; }
    }
}

using System;
using TestingOnly.Domain.Interfaces.Requests;

namespace TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Commands.RequestLoan
{
    public class RequestLoanCommandResponseViewModel: IRequestResponse
    {
        public Guid LoanId { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}

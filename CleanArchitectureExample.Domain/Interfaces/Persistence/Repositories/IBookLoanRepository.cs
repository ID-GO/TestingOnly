using System;
using System.Threading.Tasks;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Domain.Interfaces.Persistence.Repositories
{
    public interface IBookLoanRepository
    {
        Task<BookLoan> Add(BookLoan bookLoan);
        Task<BookLoan> GetByLoanId(Guid bookLoanId, bool loadBook);

        BookLoan Update(BookLoan bookLoan);
    }
}

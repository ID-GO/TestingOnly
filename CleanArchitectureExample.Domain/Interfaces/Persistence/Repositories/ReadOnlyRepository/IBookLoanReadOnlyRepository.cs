using System.Collections.Generic;
using System.Threading.Tasks;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Domain.Interfaces.Persistence.Repositories.ReadOnlyRepository
{
    public interface IBookLoanReadOnlyRepository
    {
        public Task<List<BookLoan>> GetAll(bool includeTaker, bool includeBook);
    }
}

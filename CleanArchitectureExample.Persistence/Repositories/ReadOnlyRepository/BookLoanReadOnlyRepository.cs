using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Interfaces.Persistence.Repositories.ReadOnlyRepository;
using TestingOnly.Persistence.Context;
using TestingOnly.Persistence.Repositories.Base;

namespace TestingOnly.Persistence.Repositories.ReadOnlyRepository
{
    public class BookLoanReadOnlyRepository : BaseRepositoryReadOnly<BookLoan>, IBookLoanReadOnlyRepository
    {
        public BookLoanReadOnlyRepository(ApplicationDbContextReadOnly context) : base(context)
        {
        }

        public async Task<List<BookLoan>> GetAll(bool includeTaker, bool includeBook)
        {
            var query = DbSet.AsQueryable();

            if (includeTaker)
                query = query.Include(q => q.Taker);

            if (includeBook)
                query = query.Include(q => q.Book);

            return await query.OrderBy(q => q.CheckoutDate).ToListAsync();
        }

    }
}

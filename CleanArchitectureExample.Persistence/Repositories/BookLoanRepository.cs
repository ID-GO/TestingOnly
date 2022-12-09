using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Interfaces.Persistence.Repositories;
using TestingOnly.Persistence.Context;
using TestingOnly.Persistence.Repositories.Base;

namespace TestingOnly.Persistence.Repositories
{
    public class BookLoanRepository : BaseRepository<BookLoan>, IBookLoanRepository
    {
        public BookLoanRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<BookLoan> Add(BookLoan bookLoan)
        {
            await DbSet.AddAsync(bookLoan);
            return bookLoan;
        }

        public async Task<BookLoan> GetByLoanId(Guid bookLoanId, bool loadBook)
        {
            var query = DbSet.Where(x => x.BookLoanId == bookLoanId);

            if (loadBook)
                query = query.Include(x => x.Book);

            return await query.FirstOrDefaultAsync();
        }

        public BookLoan Update(BookLoan bookLoan)
        {
            DbSet.Update(bookLoan);
            return bookLoan;
        }
    }
}

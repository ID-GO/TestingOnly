using System;
using System.Threading.Tasks;
using TestingOnly.Domain.Interfaces.Persistence.UnitOfWork;
using TestingOnly.Persistence.Context;

namespace TestingOnly.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

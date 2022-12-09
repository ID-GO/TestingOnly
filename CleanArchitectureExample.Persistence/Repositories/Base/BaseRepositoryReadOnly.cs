using Microsoft.EntityFrameworkCore;
using TestingOnly.Domain.Interfaces.Persistence;
using TestingOnly.Persistence.Context;

namespace TestingOnly.Persistence.Repositories.Base
{
    public class BaseRepositoryReadOnly<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContextReadOnly Context;
        protected DbSet<TEntity> DbSet;

        public BaseRepositoryReadOnly(ApplicationDbContextReadOnly context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }
    }
}

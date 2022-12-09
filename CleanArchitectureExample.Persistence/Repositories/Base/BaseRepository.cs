using Microsoft.EntityFrameworkCore;
using TestingOnly.Domain.Interfaces.Persistence;
using TestingOnly.Persistence.Context;

namespace TestingOnly.Persistence.Repositories.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDbContext Context;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }
    }

   
}

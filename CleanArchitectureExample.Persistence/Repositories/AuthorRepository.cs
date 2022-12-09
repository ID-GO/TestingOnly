using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Interfaces.Persistence.Repositories;
using TestingOnly.Persistence.Context;
using TestingOnly.Persistence.Repositories.Base;

namespace TestingOnly.Persistence.Repositories
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Author> AddAuthor(Author author)
        {
            await DbSet.AddAsync(author);
            return author;
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await DbSet.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<Author> GetAuthorById(Guid guid)
        {
            return await DbSet.FindAsync(guid);
        }
    }
}

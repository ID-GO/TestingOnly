using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Domain.Interfaces.Persistence.Repositories
{
    public interface IAuthorRepository
    {
        public Task<Author> AddAuthor(Author author);
        public Task<List<Author>> GetAllAuthors();
        public Task<Author> GetAuthorById(Guid guid);

    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Domain.Interfaces.Persistence.Repositories
{
    public interface IBookRepository
    {
        Task<Book> AddBook(Book book);
        Task<Book> GetBookByISBN(string ISBN);
        Task<List<Book>> GetAllBook();
        Task<List<Book>> GetByTitle(string title);
        Task<Book> GetById(Guid Id);
    }
}

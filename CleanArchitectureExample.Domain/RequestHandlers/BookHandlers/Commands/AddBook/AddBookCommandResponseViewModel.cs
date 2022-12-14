using System;
using TestingOnly.Domain.Interfaces.Requests;

namespace TestingOnly.Domain.RequestHandlers.BookHandlers.Commands.AddBook
{
    public class AddBookCommandResponseViewModel: IRequestResponse
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int Edition { get; set; }
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
    }
}

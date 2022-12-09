using System;
using TestingOnly.Domain.Interfaces.Requests;

namespace TestingOnly.Domain.RequestHandlers.AuthorsHandlers.Commands.AddAuthor
{
    public class AddAuthorCommandResponseViewModel: IRequestResponse
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
    }
}

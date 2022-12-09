using MediatR;

namespace TestingOnly.Domain.RequestHandlers.AuthorsHandlers.Commands.AddAuthor
{
    public class AddAuthorCommand:IRequest<AddAuthorCommandResponseViewModel>
    {
        public AddAuthorCommand(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}

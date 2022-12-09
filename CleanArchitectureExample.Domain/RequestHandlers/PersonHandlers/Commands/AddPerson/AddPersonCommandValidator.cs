using TestingOnly.Domain.Core.Validators;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Resources;

namespace TestingOnly.Domain.RequestHandlers.PersonHandlers.Commands.AddPerson
{
    public static class AddPersonCommandValidator
    {

        public static bool HasPersonNull(this AddPersonCommand command, Person person)
        {
            return AssertionsConcern.IsSatisfiedBy(AssertionsConcern.IsNull(person, Messages.Person_PersonWithDocumentExists));
        }
    }
}

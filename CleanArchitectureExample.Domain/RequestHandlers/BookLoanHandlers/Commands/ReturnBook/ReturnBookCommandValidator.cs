using TestingOnly.Domain.Core.Validators;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Resources;

namespace TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Commands.ReturnBook
{
    public static class ReturnBookCommandValidator
    {
        public static bool ValidateBookLoanGuid(this ReturnBookCommand command)
        {
            return AssertionsConcern.IsSatisfiedBy(AssertionsConcern.ValidateGuidFromString(command.LoanId,
                                                                                            Messages.BookReturn_LoanGuidStringIsEmpty,
                                                                                            Messages.BookReturn_LoanGuidIsEmpty,
                                                                                            Messages.BookReturn_LoanGuidIsInvalid));

        }

        public static bool ValidateBookLoanExists(this ReturnBookCommand command, BookLoan bookLoan)
        {
            return AssertionsConcern.IsSatisfiedBy(AssertionsConcern.IsNotNull(bookLoan, "Book loan not found"));
        }
    }
}

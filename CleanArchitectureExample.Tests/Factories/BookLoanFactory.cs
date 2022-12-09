using System;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Tests.Factories
{
    public static class BookLoanFactory
    {
        public static BookLoan ReturnLoan()
        {
            return new BookLoan(Guid.NewGuid(), BookFactory.ReturnBook(), PersonFactory.ReturnPerson());
        }
    }
}

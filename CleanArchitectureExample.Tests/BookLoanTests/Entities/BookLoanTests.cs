using System;
using FluentAssertions;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Enums;
using TestingOnly.Domain.Resources;
using TestingOnly.Tests.Base;
using TestingOnly.Tests.Factories;
using Xunit;

namespace TestingOnly.Tests.BookLoanTests.Entities
{
    public class BookLoanTests : TestBaseArrangements
    {
        public BookLoanTests():base()
        {
        }

        [Fact]
        public void ValidateBookLoan_ShouldReturnAllErrors()
        {
            //arrange
            BookLoan bookLoan = new BookLoan(Guid.NewGuid(), null, null);

            //act
            bookLoan.Validate();

            //assert
            DomainNotifications.GetAll().Should().HaveCount(2)
                                                                  .And.Contain(x => x == Messages.BookLoan_BookIsNull)
                                                                  .And.Contain(x => x == Messages.BookLoan_TakerIsNull);

        }

        [Fact]
        public void ValidateBookLoan_Lend_ShouldReturnNoErrors()
        {
            //arrage
            Book book = BookFactory.ReturnBook().WithBookSituation(BookSituationEnum.Awaiting);
            BookLoan bookLoan = new BookLoan(Guid.NewGuid(), book, PersonFactory.ReturnPerson());
            //act
            bookLoan.LendBook();
            //assert
            DomainNotifications.GetAll().Should().BeEmpty();
        }

        [Fact]
        public void ValidateBookLoan_Lend_ShouldReturnAlreadyLent()
        {
            //arrange
            Book book = BookFactory.ReturnBook().WithBookSituation(BookSituationEnum.Lent);
            BookLoan bookLoan = new BookLoan(Guid.NewGuid(), book, PersonFactory.ReturnPerson());

            //act
            bookLoan.LendBook();

            //assert
            DomainNotifications.GetAll().Should().HaveCount(1)
                                                     .And.Contain(x => x == Messages.BookLoan_BookIsAlreadyLent);

        }

        [Fact]
        public void ValidateBookLoadn_Return_ShouldReturnBookNotLent()
        {
            //arrange
            Book book = BookFactory.ReturnBook().WithBookSituation(BookSituationEnum.Awaiting);
            BookLoan bookLoan = new BookLoan(Guid.NewGuid(), book, PersonFactory.ReturnPerson());

            //act
            bookLoan.ReturnBook();

            //assert
            DomainNotifications.GetAll().Should().HaveCount(1)
                                                     .And.Contain(x => x == Messages.BookLoan_BookIsNotLent);
        }

        [Fact]
        public void ValidateBookLoan_Return_ShouldReturnNoErrors()
        {
            //arrage
            BookLoan bookLoan = new BookLoan(Guid.NewGuid(), BookFactory.ReturnBook().WithBookSituation(BookSituationEnum.Lent), PersonFactory.ReturnPerson());
            //act
            bookLoan.ReturnBook();
            //assert
            DomainNotifications.GetAll().Should().BeEmpty();
            bookLoan.Book.BookSituation.Value.Should().Be(BookSituationEnum.Awaiting.Value);
        }

    }
}

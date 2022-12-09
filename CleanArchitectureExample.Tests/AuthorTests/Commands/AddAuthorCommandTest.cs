using System.Threading;
using FluentAssertions;
using Moq;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Interfaces.Persistence.Repositories;
using TestingOnly.Domain.RequestHandlers.AuthorsHandlers.Commands.AddAuthor;
using TestingOnly.Tests.Base;
using Xunit;

namespace TestingOnly.Tests.AuthorTests.Commands
{
    public class AddAuthorCommandTest : TestBaseArrangements
    {
        public AddAuthorCommandTest() : base()
        {
        }

        [Theory]
        [InlineData("")]
        [InlineData("Abc")]
        [InlineData(null)]
        public async void HandleAddAuthorCommand_WithInvalidMinimumChars_ShouldReturnError(string authorName)
        {
            //Arrange
            AddAuthorCommand request = new AddAuthorCommand(authorName);
            var sut = Mocker.CreateInstance<AddAuthorCommandHandler>();
            //Act
            await sut.Handle(request, new CancellationToken());

            //Assert
            DomainNotifications.GetAll().Should().NotBeEmpty();
            Mocker.GetMock<IAuthorRepository>().Verify(x => x.AddAuthor(It.IsAny<Author>()), Times.Never);
        }

        [Fact]
        public async void HandleAddAuthorCommand_WithValidAuthor_ShouldReturnNoErrors()
        {
            //Arrange
            AddAuthorCommand request = new AddAuthorCommand("Stephen King");
            var sut = Mocker.CreateInstance<AddAuthorCommandHandler>();

            //Act
            await sut.Handle(request, new CancellationToken());

            //Assert
            DomainNotifications.GetAll().Should().BeEmpty();
            Mocker.GetMock<IAuthorRepository>().Verify(x => x.AddAuthor(It.IsAny<Author>()), Times.Once);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Interfaces.Persistence.Repositories;
using TestingOnly.Domain.RequestHandlers.PersonHandlers.Commands.AddPerson;
using TestingOnly.Tests.Base;
using Xunit;

namespace TestingOnly.Tests.PersonTests.Commands
{
    public class AddPersonCommandTest: TestBaseArrangements
    {
        public AddPersonCommandTest():base()
        {
        }

        //Test to assure the Validate method from Person domain entity was called
        [Theory]
        [InlineData("1234567891", "Andre", "user@email.com", "")]
        [InlineData("1234567897987987", "user@email.com", "Andre", null)]
        public async void HandleAddPersonCommand_WithWrongDocumentCharCount_ShouldReturnDocumentCharCountError(string document, string name, string email, string phoneNumber)
        {

            //Arrange
            var sut = Mocker.CreateInstance<AddPersonCommandHandler>();


            var request = new AddPersonCommand(document, name, email,  new List<string>() { phoneNumber });
            //Act
            await sut.Handle(request, new System.Threading.CancellationToken());

            //Assert
            DomainNotifications.GetAll().Should().NotBeEmpty();
            Mocker.GetMock<IPersonRepository>().Verify(x => x.AddPerson(It.IsAny<Person>()), Times.Never());
        }

        [Fact]
        public async void HandleAddPersonCommand_WithUser_ShouldReturnUserAlreadyExists()
        {
            //Arrange

            #region build person
            string document = "75115775122";
            string name = "Andre Santarosa";
            string phoneNumber = "19999990000";
            string email = "user@email.com";

            Person person = null;
            person = new Person(Guid.NewGuid(), document, name, email);
            List<PersonPhone> phones = new List<PersonPhone>();
            phones.Add(new PersonPhone(Guid.NewGuid(), phoneNumber, person));
            #endregion

            Mocker.GetMock<IPersonRepository>()
                .Setup(u => u.GetByDocument(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(() => Task.FromResult(person));

            var sut = Mocker.CreateInstance<AddPersonCommandHandler>();
            var personCommand = new AddPersonCommand(document, name, email, new List<string>() { phoneNumber });

            //Act
            await sut.Handle(personCommand, new System.Threading.CancellationToken());

            //Assert
            DomainNotifications.GetAll().Should().NotBeEmpty().And.Contain(x => x == Domain.Resources.Messages.Person_PersonWithDocumentExists)
                                                              .And.HaveCount(1);
            Mocker.GetMock<IPersonRepository>().Verify(x => x.GetByDocument(It.IsAny<string>(), It.IsAny<bool>()), Times.Once());
            Mocker.GetMock<IPersonRepository>().Verify(x => x.AddPerson(It.IsAny<Person>()), Times.Never());
        }

        [Fact]
        public async void HandleAddPersonCommand_WithUser_ShouldReturnSuccessWithNoErrors()
        {
            //Arrange

            #region build person
            string document = "75115775122";
            string name = "Andre Santarosa";
            string phoneNumber = "19999990000";
            string email = "user@email.com";

            Person person = null;
            person = new Person(Guid.NewGuid(), document, name, email);
            List<PersonPhone> phones = new List<PersonPhone>();
            phones.Add(new PersonPhone(Guid.NewGuid(), phoneNumber, person));
            #endregion

            Mocker.GetMock<IPersonRepository>()
                .Setup(u => u.GetByDocument(It.IsAny<string>(), It.IsAny<bool>()))
                .Returns(() => Task.FromResult<Person>(null));

            var sut = Mocker.CreateInstance<AddPersonCommandHandler>();
            var personCommand = new AddPersonCommand(document, name, email, new List<string>() { phoneNumber });

            //Act
            var addResponse = await sut.Handle(personCommand, new System.Threading.CancellationToken());

            //Assert
            DomainNotifications.GetAll().Should().BeEmpty();
            addResponse.Should().NotBeNull();
            addResponse.PersonId.Should().NotBeEmpty().Should().NotBeNull();
            addResponse.PhoneNumbers.Should().HaveCountGreaterThan(0);
            Mocker.GetMock<IPersonRepository>().Verify(x => x.GetByDocument(It.IsAny<string>(), It.IsAny<bool>()), Times.Once());
            Mocker.GetMock<IPersonRepository>().Verify(x => x.AddPerson(It.IsAny<Person>()), Times.Once());
        }



    }
}

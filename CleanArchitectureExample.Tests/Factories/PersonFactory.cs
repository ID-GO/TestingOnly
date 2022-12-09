using System;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Tests.Factories
{
    public static class PersonFactory
    {
        public static Person ReturnPerson()
        {
            return new Person(Guid.NewGuid(), "32145678996", "Andre Santarosa", "user@email.com");
        }
    }
}

using System;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Tests.Factories
{
    public static class AuthorFactory
    {
        public static Author ReturnAuthor()
        {
            return new Author(Guid.NewGuid(), "Stephen King");
        }
    }
}

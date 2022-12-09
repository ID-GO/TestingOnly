using System;

namespace TestingOnly.Domain.Core.DomainNotification
{
    public interface IContainer
    {
        T GetService<T>(Type type);
    }
}

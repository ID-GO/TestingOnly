using System.Collections.Generic;

namespace TestingOnly.Domain.Core.DomainNotification
{
    public interface IDomainNotifications
    {
        void AddNotification(string notification);
        bool HasNotifications();
        List<string> GetAll();
        void CleanNotifications();
    }
}

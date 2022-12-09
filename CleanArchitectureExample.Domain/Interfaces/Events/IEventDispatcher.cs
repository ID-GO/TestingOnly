using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;

namespace TestingOnly.Domain.Interfaces.Events
{
    public interface IEventDispatcher
    {
        List<INotification> GetPreCommitEvents();
        void AddPreCommitEvent(INotification evt);
        void RemovePreCommitEvent(INotification evt);
        Task FirePreCommitEvents();


        List<INotification> GetAfterCommitEvents();
        void AddAfterCommitEvent(INotification evt);
        void RemoveAfterCommitEvent(INotification evt);
        Task FireAfterCommitEvents();
    }
}

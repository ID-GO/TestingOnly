using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestingOnly.Domain.Interfaces.Services.Communication;

namespace TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Commands.RequestLoan.Events
{

    public class LoanEffetivatedEventSendSms : INotificationHandler<LoanEffetivatedEvent>
    {
        private readonly ISmsServices _smsServices;

        public LoanEffetivatedEventSendSms(ISmsServices smsServices)
        {
            _smsServices = smsServices;
        }

        async Task INotificationHandler<LoanEffetivatedEvent>.Handle(LoanEffetivatedEvent notification, CancellationToken cancellationToken)
        {
            await _smsServices.SendSms(notification.Phone,  $"Book {notification.BookName} lent, expected return date {notification.ReturnDate.ToShortDateString()}");
        }
    }
}

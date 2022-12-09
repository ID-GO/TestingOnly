using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestingOnly.Domain.Interfaces.Services.Communication;

namespace TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Commands.RequestLoan.Events
{
    public class LoanEffetivatedEventSendMail : INotificationHandler<LoanEffetivatedEvent>
    {
        private readonly IEmailServices _emailServices;

        public LoanEffetivatedEventSendMail(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        async Task INotificationHandler<LoanEffetivatedEvent>.Handle(LoanEffetivatedEvent notification, CancellationToken cancellationToken)
        {
            await _emailServices.SendEmail(new List<string> { notification.Email }, "Book loan", $"Book {notification.BookName} lent, expected return date {notification.ReturnDate.ToShortDateString()}");            
        }
    }
}

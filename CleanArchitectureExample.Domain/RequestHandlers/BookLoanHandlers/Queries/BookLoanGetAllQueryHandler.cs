using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Interfaces.Persistence.Repositories.ReadOnlyRepository;

namespace TestingOnly.Domain.RequestHandlers.BookLoanHandlers.Queries
{
    public class BookLoanGetAllQueryHandler : IRequestHandler<BookLoanGetAllQuery, BookLoanGetAllQueryResponseViewModel>
    {
        private readonly IBookLoanReadOnlyRepository _bookLoanReadOnlyRepository;

        public BookLoanGetAllQueryHandler(IBookLoanReadOnlyRepository bookLoanReadOnlyRepository)
        {
            _bookLoanReadOnlyRepository = bookLoanReadOnlyRepository;
        }

        public async Task<BookLoanGetAllQueryResponseViewModel> Handle(BookLoanGetAllQuery request, CancellationToken cancellationToken)
        {
            BookLoanGetAllQueryResponseViewModel response = new BookLoanGetAllQueryResponseViewModel();

            List<BookLoan> bookLoans = await _bookLoanReadOnlyRepository.GetAll(true, true);

            bookLoans.ForEach(x =>
            {
                response.BookLoans.Add(new BookLoanGetAllQueryResponseViewModelItem
                {
                    BookLoanId = x.BookLoanId,
                    BookId = x.BookId,
                    BookTitle = x.Book.Title,
                    TakerId = x.Taker.PersonId,
                    TakerName = x.Taker.Name,
                    CheckoutDate = x.CheckoutDate,
                    ExpectedReturnDate = x.ExpectedReturnDate
                });
            });

            return response;

        }
    }
}
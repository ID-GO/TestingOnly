using System;
using System.Collections.Generic;
using TestingOnly.Domain.Interfaces.Requests;

namespace TestingOnly.Domain.RequestHandlers.PersonHandlers.Queries.GetAll
{
    public class GetAllPeopleQueryViewModel: IRequestResponse
    {
        public List<AddPersonCommandResultViewPerson> Person { get; set; } = new List<AddPersonCommandResultViewPerson>();

        public class AddPersonCommandResultViewPerson
        {
            public Guid PersonId { get; set; }
            public string Document { get; set; }
            public string Name { get; set; }
        }
    }
}

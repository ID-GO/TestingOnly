using System;
using TestingOnly.Domain.Base;

namespace TestingOnly.Domain.Entities
{
    public class PersonPhone : BaseEntity
    {
        public PersonPhone()
        {

        }
        public PersonPhone(Guid personPhoneId, string phoneNumber, Person person)
        {
            PersonPhoneId = personPhoneId;
            PhoneNumber = phoneNumber;
            Person = person;
        }

        public Guid PersonPhoneId { get; private set; }
        public string PhoneNumber { get; private set; }
        public Guid PersonId { get; private set; }

        #region .:: Navigation Properties ::.
        public virtual Person Person { get; private set; }
        #endregion
    }
}

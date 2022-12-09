using System.Collections.Generic;
using System.Threading.Tasks;
using TestingOnly.Domain.Entities;

namespace TestingOnly.Domain.Interfaces.Persistence.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> AddPerson(Person person);
        Task<Person> GetByDocument(string document, bool loadPhone = false);
        Task<List<Person>> GetAll();
    }
}

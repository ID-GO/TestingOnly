using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestingOnly.Domain.Entities;
using TestingOnly.Domain.Interfaces.Persistence.Repositories;
using TestingOnly.Persistence.Context;
using TestingOnly.Persistence.Repositories.Base;

namespace TestingOnly.Persistence.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Person> AddPerson(Person person)
        {
            await DbSet.AddAsync(person);
            return person;
        }

        public async Task<List<Person>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Person> GetByDocument(string document, bool loadPhone = false)
        {
            var query = DbSet.Where(p => p.Document == document);

            if (loadPhone)
                query.Include(p => p.PhoneNumbers);

            return await query.FirstOrDefaultAsync();
        }
    }
}

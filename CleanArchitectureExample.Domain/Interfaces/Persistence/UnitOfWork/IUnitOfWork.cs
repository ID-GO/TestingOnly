using System.Threading.Tasks;

namespace TestingOnly.Domain.Interfaces.Persistence.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task<bool> Commit();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestingOnly.Domain.Interfaces.Services.Communication
{
    public interface IEmailServices
    {
        Task SendEmail(List<string> recipient, string subject, string message);
    }
}

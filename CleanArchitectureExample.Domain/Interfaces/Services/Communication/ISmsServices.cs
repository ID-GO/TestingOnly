using System.Threading.Tasks;

namespace TestingOnly.Domain.Interfaces.Services.Communication
{
    public interface ISmsServices
    {
        Task SendSms(string phoneNumber, string text);
    }
}

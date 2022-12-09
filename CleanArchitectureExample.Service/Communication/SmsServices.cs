using System;
using System.Threading.Tasks;
using TestingOnly.Domain.Interfaces.Events;
using TestingOnly.Domain.Interfaces.Services.Communication;

namespace TestingOnly.Service.Communication
{
    public class SmsServices : ISmsServices
    {
        private readonly IEventDispatcher _eventDispatcher;

        public SmsServices(IEventDispatcher eventDispatcher)
        {
            this._eventDispatcher = eventDispatcher;
        }

        public async Task SendSms(string phoneNumber, string text)
        {
            await Task.Delay(1000);
            Console.WriteLine("SMS Sent");
            //SMS sent

        }
    }
}

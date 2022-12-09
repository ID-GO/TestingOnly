using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;
using TestingOnly.Domain.Interfaces.Services.Communication;

namespace TestingOnly.Service.Communication
{
    public class EmailServices : IEmailServices
    {
        private AsyncRetryPolicy retryPolice;

        public EmailServices()
        {
            retryPolice = Policy.Handle<TimeoutException>().WaitAndRetryAsync(5, i => TimeSpan.FromMilliseconds(500));
        }

        public async Task SendEmail(List<string> recipient, string subject, string message)
        {
            var rand = 0;
            await retryPolice.ExecuteAsync(async () =>
            {
                Console.WriteLine("Trying to send email");
                // Force exception for demo purpose
                if (rand <=2)
                {
                    rand++;
                    throw new TimeoutException();
                }
                    
                await Task.Delay(1000);
                Console.WriteLine("Email Sent");
            });
        }
    }
}

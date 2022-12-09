using System;
using Microsoft.AspNetCore.Http;
using TestingOnly.Domain.Core.DomainNotification;

namespace TestingOnly.Application.DomainNotifications
{
    public class HttpContextServiceProviderProxy : IContainer
    {
        private readonly IHttpContextAccessor contextAccessor;

        public HttpContextServiceProviderProxy(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public T GetService<T>(Type type)
        {
            return (T)contextAccessor.HttpContext.RequestServices.GetService(type);
        }
    }
}

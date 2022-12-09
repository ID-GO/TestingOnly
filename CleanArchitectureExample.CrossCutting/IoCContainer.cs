using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestingOnly.Application.DomainNotifications;
using TestingOnly.Application.Events;
using TestingOnly.Application.Orchestration;
using TestingOnly.Domain.Core.DomainNotification;
using TestingOnly.Domain.Interfaces.Events;
using TestingOnly.Domain.Interfaces.Persistence.Repositories;
using TestingOnly.Domain.Interfaces.Persistence.Repositories.ReadOnlyRepository;
using TestingOnly.Domain.Interfaces.Persistence.UnitOfWork;
using TestingOnly.Domain.Interfaces.Services.Communication;
using TestingOnly.Persistence.Context;
using TestingOnly.Persistence.Repositories;
using TestingOnly.Persistence.Repositories.ReadOnlyRepository;
using TestingOnly.Persistence.UnitOfWork;
using TestingOnly.Service.Communication;

namespace TestingOnly.CrossCutting
{
    public class IoCContainer
    {
        public static void InitializeContainer(IServiceCollection services)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=TestingOnly;Persist Security Info=False;User ID=sa;Password=123456;";

            //Inject external tools
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("TestingOnly.Domain"));
            services.AddMediatR(AppDomain.CurrentDomain.Load("TestingOnly.Domain"));

            //Entity Framework
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<ApplicationDbContextReadOnly>(options => options.UseSqlServer(connectionString));


            //Inject internal work classes
            services.AddScoped<IOrchestrator, Orchestrator>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDomainNotifications, DomainNotifications>();
            services.AddSingleton<IContainer, HttpContextServiceProviderProxy>();
            services.AddScoped<IEventDispatcher, EventDispatcher>();


            //Entity Framework Repositories
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookLoanRepository, BookLoanRepository>();

            //ReadOnly repositories
            services.AddScoped<IBookLoanReadOnlyRepository, BookLoanReadOnlyRepository>();

            //Services
            services.AddScoped<ISmsServices, SmsServices>();
            services.AddScoped<IEmailServices, EmailServices>();
        }
    }
}

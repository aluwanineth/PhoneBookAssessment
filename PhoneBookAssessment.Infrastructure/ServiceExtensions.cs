using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBookAssessment.Application.Interfaces;
using PhoneBookAssessment.Application.Interfaces.Repositories;
using PhoneBookAssessment.Infrastructure.Contexts;
using PhoneBookAssessment.Infrastructure.Repositories;
using System;

namespace PhoneBookAssessment.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            
            //services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IPhoneBookRepositoryAsync, PhoneBookRepositoryAsync>();
            services.AddTransient<IEntryRepositoryAsync, EntryRepositoryAsync>();
        }
    }
}

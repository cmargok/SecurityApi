using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Application.Models.Security;
using RedSecure.Infrastructure.Persistence;
using RedSecure.Infrastructure.Persistence.Repositories;

namespace RedSecure.Api.Configurations.Modules.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApplicationDBContext>(
                 options =>
                 {
                     options.UseSqlServer(Environment.GetEnvironmentVariable("SecurityDb"));
                 }
                 
            //   ,bv => bv.MigrationsAssembly(typeof(IdentityDBContext).Assembly.FullName)
            );

            services.AddIdentity<ApiUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDBContext>()
                .AddDefaultTokenProviders();

            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPreRegisterRepository, PreRegisterRepository>();

            return services;
        }
    }
}


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.Application.Core;
using Security.Application.InfrastructureContracts;
using Security.Infrastructure.Persistence.Repositories;

namespace Security.API.Configurations
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPreRegisterRepository, PreRegisterRepository>();
            services.AddScoped<ISecureGuardian, SecureGuardian>();
            return services;
        }
    }
}
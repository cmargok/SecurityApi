using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Security.Application.Configurations.Core;
using Security.Application.InfrastructureContracts;
using Security.Infrastructure.Persistence.Repositories;

namespace Security.Services.Configurations
{
    public static class DIcontainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPreRegisterRepository, PreRegisterRepository>();
            services.AddScoped<ISecureGuardian, SecureGuardian>();
            return services;
        }
    }
}
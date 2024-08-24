using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Models.Settings;
using RedSecure.Application.UseCases.PreRegistration;

namespace RedSecure.Api.Configurations.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.Configure<CryptoSettings>(o => o.Salt = Environment.GetEnvironmentVariable("CryptoSettings")!);
            services.AddScoped<IPreRegistrationHandler, PreRegistrationHandler>();
            return services;
        }


    }
}

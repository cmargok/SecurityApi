using RedSecure.Application.Contracts.Handlers;
using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Handlers;
using RedSecure.Application.Handlers.Jwt;
using RedSecure.Application.UseCases.Login;
using RedSecure.Application.UseCases.PreRegistration;
using RedSecure.Application.UseCases.SignUp;
using RedSecure.Domain.Settings;
using RedSecure.Domain.Utils.Hash;

namespace RedSecure.Api.Configurations.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.Configure<CryptoSettings>(o => o.Salt = Environment.GetEnvironmentVariable("CryptoSettings")!);
            services.AddScoped<IPreRegistrationHandler, PreRegistrationHandler>();
            services.AddScoped<ISignUpHandler, SignUpHandler>();
            services.AddScoped<IIdentityHandler, IdentityHandler>();
            services.AddScoped<IAuditHandler, AuditHandler>();
            services.AddScoped<ILoginHandler, LoginHandler>();
            return services;
        }

        public static IServiceCollection AddDomainDependencies(this IServiceCollection services)
        {
      
            services.AddScoped<IHashHandler, HashHandler>();
            return services;
        }

    }
}

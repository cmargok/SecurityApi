using RedSecure.Application.Contracts.Handlers;
using RedSecure.Application.Handlers.Jwt;
using RedSecure.Domain.Settings;

namespace RedSecure.Api.Configurations.Modules.Authentication
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            AddClientOptions<JwtSettings>(services, "JwtSettings");

            services.PostConfigure<JwtSettings>(opt => opt.SecureKey = Environment.GetEnvironmentVariable("symKey")!);
            services.AddScoped<IAuthJedi, AuthJedi>();
            return services;
        }

        private static void AddClientOptions<T>(IServiceCollection services, string serviceRoute) where T : class
        {
            services
                .AddOptions<T>()
                .BindConfiguration(serviceRoute)
                .ValidateDataAnnotations()
                .ValidateOnStart();
        }
    }
}
using RedSecure.Infrastructure.Correlation;

namespace RedSecure.Api.Configurations.Modules.Correlation
{
    public static class CorrelationExtensions
    {
        public static IServiceCollection AddCorrelationId(this IServiceCollection services)
        {
            services.AddScoped<ICorrelationIdSentinel, CorrelationIdSentinel>();
            return services;
        }
    }

  
}

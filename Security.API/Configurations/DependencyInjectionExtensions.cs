
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.Application.Core;
using Security.Application.InfrastructureContracts;
using Security.Application.PreRecording;
using Security.Infrastructure.Externals.Notifications;
using Security.Infrastructure.Persistence.Repositories;
using System.Net.Http.Headers;

namespace Security.API.Configurations
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPreRecord, PreRecord>();
            services.AddScoped<ISecureGuardian, SecureGuardian>();
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            AddNotificationsApiClient(services, config["NotificationsApi:Url"]!);
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPreRegisterRepository, PreRegisterRepository>();
            
            return services;
        }
        


        private static void AddNotificationsApiClient(IServiceCollection services, string Url)
        {
            services.AddHttpClient<INotificationsApi, NotificationsApi>(
                client =>
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(Url);
                });
        }
    }
}
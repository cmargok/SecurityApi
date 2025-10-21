//    using MassTransit;
//using RedSecure.Application.Contracts.Infrastructure;
//using RedSecure.Application.Models.NotifyEvent;
//using RedSecure.Infrastructure.Events.Notifications;

//namespace RedSecure.Api.Configurations.Modules.Events
//{
//    public static class EventExtensions
//    {
//        public static IServiceCollection AddNotificationsApiEvent(this IServiceCollection services)
//        {

//            //services.AddMassTransit(configuration =>
//            //{
//            //    configuration.UsingRabbitMq((context, config) =>
//            //    {
//            //        config.Host(host: "localhost", 5672, "/", hostConfig =>
//            //        {
//            //            hostConfig.Username("guest");
//            //            hostConfig.Password("guest");
//            //        });
//            //        config.Message<EmailRequest>(c => c.SetEntityName("EmailEvent"));
//            //        config.ConfigureEndpoints(context);
//            //    });
                
//            //});

//            //services.AddScoped<INotifyEventHandler, NotifyEventHandler>();
//            return services;
//        }
//    }
//}

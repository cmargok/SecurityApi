using MassTransit;
using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Application.Models.NotifyEvent;
using RedSecure.Infrastructure.Correlation;

namespace RedSecure.Infrastructure.Events.Notifications
{

    public class NotifyEventHandler : INotifyEventHandler
    {
        private readonly IPublishEndpoint _publisherEndpoint;
        private readonly ICorrelationIdSentinel _correlationIdSentinel;

        public NotifyEventHandler(IPublishEndpoint publisherEndpoint, ICorrelationIdSentinel correlationIdSentinel)
        {
            _publisherEndpoint = publisherEndpoint;
            _correlationIdSentinel = correlationIdSentinel;
        }
        public async Task SendEmailEvent(EmailToSendDto @event, CancellationToken cancellationToken = default)
        {
            await _publisherEndpoint.Publish(@event, sendContext =>
            {
                sendContext.CorrelationId = Guid.Parse(_correlationIdSentinel.Get());

            }, cancellationToken);

        }
    }

    
}

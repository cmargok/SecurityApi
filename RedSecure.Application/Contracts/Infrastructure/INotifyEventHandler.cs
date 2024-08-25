using RedSecure.Application.Models.NotifyEvent;

namespace RedSecure.Application.Contracts.Infrastructure
{
    public interface INotifyEventHandler
    {
        Task SendEmailEvent(EmailToSendDto @event, CancellationToken cancellationToken = default);
    }
}

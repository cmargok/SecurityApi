using MassTransit;
using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Application.Models.NotifyEvent;
using RedSecure.Domain.Templates;
using RedSecure.Infrastructure.Correlation;

namespace RedSecure.Infrastructure.Events.Notifications
{
    public class NotifyEventHandler : INotifyEventHandler
    {
        private readonly IPublishEndpoint _publisherEndpoint;
        private readonly ICorrelationIdSentinel _correlationIdSentinel;
        private const string Subject = "Pre-Registration - CmargokSystems";
        public NotifyEventHandler(IPublishEndpoint publisherEndpoint, ICorrelationIdSentinel correlationIdSentinel)
        {
            _publisherEndpoint = publisherEndpoint;
            _correlationIdSentinel = correlationIdSentinel;
        }

        public async Task<bool> SendPreRegisterEmail(string emailTo, string name, string code, CancellationToken cancellationToken = default)
        {
            var body = LoadHtmlTemplate(name, code);
            if (body is "")
                return false;

            var emailEvent = new EmailRequest()
            {
                EmailsTo = [ new() { DisplayName = name, Email = emailTo }],
                Subject = Subject,
                Html = true,
                HtmlBody = body,
            };

            await SendEmailEvent(emailEvent, cancellationToken);

            return true;
        }

       

        private async Task SendEmailEvent(EmailRequest @event, CancellationToken cancellationToken = default)
        {
            await _publisherEndpoint.Publish<EmailRequest>(@event, sendContext =>
            {
                sendContext.CorrelationId = Guid.Parse(_correlationIdSentinel.Get());

            }, cancellationToken);
        }

        private static string LoadHtmlTemplate(string Name, string CodeAccess)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(CodeAccess))
                return "";

            string htmlBody = HtmlTemplates.GetPreRegisterTemplate();

            return string.Format(htmlBody, Name, CodeAccess);
        }
    }

    
}

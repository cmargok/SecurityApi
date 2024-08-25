using System.ComponentModel.DataAnnotations;

namespace RedSecure.Application.Models.NotifyEvent
{
    public record EmailToSendDto
    {
        [EmailAddress]
        public string EmailFrom { get; init; } = string.Empty;
        public string DisplayName { get; init; } = string.Empty;
        public List<To> EmailsTo { get; init; } = [];
        public string Subject { get; init; } = string.Empty;
        public string Message { get; init; } = string.Empty;
        public bool Html { get; init; }
        public string HtmlBody { get; init; } = string.Empty;

        public record To
        {
            public string DisplayName { get; init; } = string.Empty;

            [EmailAddress]
            public string Email { get; init; } = string.Empty;
        }
    }
}

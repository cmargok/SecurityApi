namespace Security.Application.InfrastructureContracts
{
    public interface INotificationsApi
    {
        public Task<bool> SendEmailAsync(Email email);
    }
    public class Email
    {
        public string To { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

    }
}

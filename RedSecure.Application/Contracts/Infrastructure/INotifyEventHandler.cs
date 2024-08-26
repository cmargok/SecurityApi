namespace RedSecure.Application.Contracts.Infrastructure
{
    public interface INotifyEventHandler
    {
        public Task<bool> SendPreRegisterEmail(string emailTo, string name, string code, CancellationToken cancellationToken = default);
    }
}

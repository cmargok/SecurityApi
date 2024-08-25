namespace RedSecure.Api.Configurations.Modules.Correlation
{
    public class CorrelationIdSentinel : ICorrelationIdSentinel
    {
        private string _correlationId = Guid.NewGuid().ToString();
        private const string CorrelationIdHeader = "X-Correlation-Id";
        public string Get() => _correlationId;
        public string GetHeaderName() => CorrelationIdHeader;
        public void Set(string correlationId) => _correlationId = correlationId;
    }
    public interface ICorrelationIdSentinel
    {
        public string Get();
        public void Set(string correlationId);

        public string GetHeaderName();
    }
}

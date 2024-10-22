﻿namespace RedSecure.Infrastructure.Correlation
{
    public interface ICorrelationIdSentinel
    {
        public string Get();
        public void Set(string correlationId);
        public string GetHeaderName();
    }

    public class CorrelationIdSentinel : ICorrelationIdSentinel
    {
        private const string CorrelationIdHeader = "X-Correlation-Id";

        private string _correlationId = "";

        public string Get()
            => _correlationId is "" ? Guid.NewGuid().ToString()  : _correlationId;
        public string GetHeaderName()
            => CorrelationIdHeader;
        public void Set(string correlationId)
            => _correlationId = correlationId;
    }

}

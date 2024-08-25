using RedSecure.Domain.Entities;

namespace RedSecure.Application.Contracts.Infrastructure
{
    public interface IAuditRepository
    {
        public void AddToken(TokenLog tokenLog);
        public Task<int> SaveAsync();
        public Task<int> BlockTokenAsync(string token, string blockIssuer, string blockReason);
        public Task<int> BlockAllTokensAsync(string user, string blockIssuer, string blockReason);
        public Task BlockExpiredTokensByJobAsync<T>(string blockIssuer, string blockReason) where T : BlockandDateFields;

    }
}

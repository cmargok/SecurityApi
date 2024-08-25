using RedSecure.Application.Models.Handlers.Jwt;
using RedSecure.Domain.Utils.Constants;

namespace RedSecure.Application.Contracts.Handlers
{
    public interface IAuditHandler
    {
        public Task<bool> AuditToken(JwtUserData user, TokenData tokenData);

        public Task<bool> BlockTokenAsync(string token, string blockIssuer = Constants.Issuers.Internal, string blockReason = Constants.Reasons.TokenLoockedToPrevent);
        public Task<bool> BlockAllTokensAsync(string user, string blockIssuer = Constants.Issuers.Internal, string blockReason = Constants.Reasons.TokenLoockedToPrevent);
    }





}

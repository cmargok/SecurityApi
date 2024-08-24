using RedSecure.Application.Models.Security;

namespace RedSecure.Application.Contracts.Handlers
{
    public interface IIdentityHandler
    {
        public Task<(bool created, string errors)> CreateAsync(ApiUser user, string password);
        public Task<bool> VerifyIfUserIsRegisteredAready(string user, string email);
    }

}

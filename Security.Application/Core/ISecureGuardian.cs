using Microsoft.AspNetCore.Identity;
using Security.Application.Models.Security;

namespace Security.Application.Core
{
    public interface ISecureGuardian
    {
        public Task<IEnumerable<IdentityError>> Register(ApiUserDto apiuser);
    }
}

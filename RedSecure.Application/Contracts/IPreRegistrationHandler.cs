using RedSecure.Application.Models.PreRegister;
using RedSecure.Application.Utils;

namespace RedSecure.Application.Contracts
{
    public interface IPreRegistrationHandler
    {
        public Task<ApiResponse<bool>> PreRegistrationAsync(PreRegisterDto preRegister, CancellationToken token);
    }

}

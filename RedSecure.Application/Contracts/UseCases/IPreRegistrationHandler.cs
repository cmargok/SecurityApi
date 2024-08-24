using RedSecure.Application.Models.PreRegister;
using RedSecure.Domain.Utils;

namespace RedSecure.Application.Contracts.UseCases
{
    public interface IPreRegistrationHandler
    {
        public Task<ApiResponse<bool>> PreRegistrationAsync(PreRegisterDRequest preRegister, CancellationToken cancellationToken = default);
    }

}

using RedSecure.Application.Models.PreRegister;
using RedSecure.Domain.Utils;

namespace RedSecure.Application.Contracts.UseCases
{
    public interface IPreRegistrationHandler
    {
        public Task<ApiResponse<bool>> PreRegistrationAsync(PreRegisterDto preRegister, CancellationToken cancellationToken = default);
    }

}

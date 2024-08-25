using RedSecure.Application.Models.SignUp;
using RedSecure.Domain.Utils;

namespace RedSecure.Application.Contracts.UseCases
{
    public interface ISignUpHandler
    {
        Task<ApiResponse<bool>> SignUpAsync(SignUpRequest signUpRequest, CancellationToken cancellationToken = default);
    }
}
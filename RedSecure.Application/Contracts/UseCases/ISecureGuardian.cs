using RedSecure.Application.Models.SignIn;
using RedSecure.Domain.Utils;

namespace RedSecure.Application.Contracts.UseCases
{
    public interface ISecureGuardian
    {
        Task<ApiResponse<bool>> SignInAsync(SignInRequest signInRequest, CancellationToken cancellationToken = default);
    }
}
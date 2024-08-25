using RedSecure.Application.Models.Login;
using RedSecure.Application.Models.Shared;
using RedSecure.Domain.Utils;

namespace RedSecure.Application.Contracts.Handlers
{
    public interface ILoginHandler
    {
        public Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default);
    }
}
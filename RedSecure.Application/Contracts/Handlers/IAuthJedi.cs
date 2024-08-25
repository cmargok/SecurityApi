using RedSecure.Application.Models.Handlers.Jwt;
using RedSecure.Application.Models.Login;
using RedSecure.Domain.Utils;

namespace RedSecure.Application.Contracts.Handlers
{
    public interface IAuthJedi
    {
        public Task<ApiResponse<AuthTokenResponse>> EmanateTokenAsync(JwtUserData userData);
    }





}

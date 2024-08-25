using Microsoft.Extensions.Options;
using RedSecure.Application.Contracts.Handlers;
using RedSecure.Application.Models.Handlers.Jwt;
using RedSecure.Application.Models.Login;
using RedSecure.Domain.Settings;
using RedSecure.Domain.Utils;

namespace RedSecure.Application.Handlers.Jwt
{

    public sealed class AuthJedi : IAuthJedi
    {

        private readonly TokenPadawan _tokenPadawan;
        private readonly IAuditHandler _auditHandler;

        public AuthJedi(IAuditHandler auditHandler, IOptions<JwtSettings> settings)
        {
            _tokenPadawan =  new TokenPadawan(settings.Value);
            _auditHandler = auditHandler;
        }

        public async Task<ApiResponse<AuthTokenResponse>> EmanateTokenAsync(JwtUserData userData)
        {
            var tokenData = _tokenPadawan.CreateToken(userData);

            _ = await _auditHandler.AuditToken(userData, tokenData);

            var result = new AuthTokenResponse()
            {
                JwtToken = tokenData.Token,
                Type = tokenData.Type,
                Scope = tokenData.Scope,
            };

            return Response.Success(result);
        }

    }





}

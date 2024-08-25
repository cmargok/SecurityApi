using RedSecure.Application.Contracts.Handlers;
using RedSecure.Application.Models.Handlers.Jwt;
using RedSecure.Application.Models.Login;
using RedSecure.Application.Models.Shared;
using RedSecure.Domain.Utils;
using RedSecure.Domain.Utils.Constants;

namespace RedSecure.Application.UseCases.Login
{
    public class LoginHandler : ILoginHandler
    {
        private readonly IIdentityHandler _identityHandler;
        private readonly IAuthJedi _authJedi;
        public LoginHandler(IIdentityHandler identityHandler, IAuthJedi authJedi)
        {
            _identityHandler = identityHandler;
            _authJedi = authJedi;
        }

        public async Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var signedIn = await _identityHandler.LogInAsync(request.UserName, request.Password);

            if (!signedIn.status)
                return Response.Error<AuthResponse>(null!, "sign in has failed", signedIn.result);

            var response = new AuthResponse()
            {
                UserName = request.UserName,
            };

            var user = await _identityHandler.GetUserAsync(request.UserName);
            if (user is null)
                return Response.Error<AuthResponse>(null!, "sign in has failed", Constants.ErrorMessages.ErrorGeneral);

            response.Email = user!.Email!;
            var roles = await _identityHandler.GetRolesAsync(user!);


            var dataToJwt = new JwtUserData()
            {
                Id = user.Id,
                Email = user.Email,
                UserName = request.UserName,
                UserRole = roles.Count > 0 ? roles[0] : "default"
            };

            var JwtResult = await _authJedi.EmanateTokenAsync(dataToJwt);

            response.Auth = JwtResult.Values!;

            return Response.Success(response, message: Constants.OkMessages.AccessGranted);
        }
    }

}
 
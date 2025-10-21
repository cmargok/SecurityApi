using RedSecure.Application.Contracts.Handlers;
using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Models.Security;
using RedSecure.Application.Models.SignUp;
using RedSecure.Domain.Entities;
using RedSecure.Domain.Utils;
using RedSecure.Domain.Utils.Constants;
using RedSecure.Domain.Utils.Cryptography;

namespace RedSecure.Application.UseCases.SignUp
{
    public class SignUpHandler : ISignUpHandler
    {
        private readonly IPreRegisterRepository _preRegisterRepository;
        private readonly IIdentityHandler _identityHandler;

        public SignUpHandler(IPreRegisterRepository preRegisterRepository, IIdentityHandler identityHandler)
        {
            _preRegisterRepository = preRegisterRepository;
            _identityHandler = identityHandler;
        }

        public async Task<ApiResponse<bool>> SignUpAsync(SignUpRequest signUpRequest, CancellationToken cancellationToken = default)
        {
            if (await _identityHandler.VerifyIfUserIsRegisteredAready(signUpRequest.Username, signUpRequest.Email))
                return Response.Error(false, Constants.ErrorMessages.UserExists, Constants.ErrorMessages.UserExists);

            var userData = await _preRegisterRepository.GetRecordAsync(signUpRequest.Email, signUpRequest.Username, signUpRequest.SecretCode, cancellationToken);
            if (userData is null)
                return Response.Error(false, Constants.ErrorMessages.ErrorGeneral, Constants.ErrorMessages.UserNotFound);

            var newUser = Map(signUpRequest, userData);

            var isCreated = await _identityHandler.CreateAsync(newUser, newUser.PasswordHash!);

            if (!isCreated.created)
                return Response.Error(false, Constants.ErrorMessages.ErrorGeneral, isCreated.errors);

            return Response.Success(true, message: Constants.OkMessages.UserRegisterd);
        }

        private static ApiUser Map(SignUpRequest signUpRequest, PreRegister preRegister)
        {
            var (pass, salt) = CryptoService.HashPassword(signUpRequest.Password);

            return new ApiUser()
            {
                RegisterAt = DateTime.UtcNow,
                UserName = preRegister.HashUserName,
                Email = signUpRequest.Email,
                FirstName = preRegister.FirstName,
                LastName = preRegister.LastName,
                PhoneNumber = preRegister.PhoneNumber,
                NoHashedUserName = signUpRequest.Username,
                UserSalt = salt,
                PasswordHash = pass,
            };
        }


    }

}

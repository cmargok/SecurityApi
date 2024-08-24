using RedSecure.Application.Contracts.Handlers;
using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Models.Security;
using RedSecure.Application.Models.SignIn;
using RedSecure.Domain.Entities;
using RedSecure.Domain.Utils;
using RedSecure.Domain.Utils.Hash;

namespace RedSecure.Application.UseCases.SignIn
{
    public class SecureGuardian : ISecureGuardian
    {
        private readonly IPreRegisterRepository _preRegisterRepository;
        private readonly IIdentityHandler _identityHandler;
        private readonly IHashHandler _hashHandler;

        public SecureGuardian(IPreRegisterRepository preRegisterRepository, IIdentityHandler identityHandler, IHashHandler hashHandler)
        {
            _preRegisterRepository = preRegisterRepository;
            _identityHandler = identityHandler;
            _hashHandler = hashHandler;
        }

        public async Task<ApiResponse<bool>> SignInAsync(SignInRequest signInRequest, CancellationToken cancellationToken = default)
        {
            if (await _identityHandler.VerifyIfUserIsRegisteredAready(signInRequest.Username, signInRequest.Email))
                return Response.Error(false, "Already registered user", "User already exists in the platform.");

            var userData = await _preRegisterRepository.GetRecordAsync(signInRequest.Email, signInRequest.Username, signInRequest.SecretCode, cancellationToken);
            if (userData is null)
                return Response.Error(false, "Error - code", "User was not found.");

            var isCreated = await _identityHandler.CreateAsync(Map(signInRequest, userData), signInRequest.Password);

            if (!isCreated.created)
                return Response.Error(false, "Error - user not created", isCreated.errors);

            return Response.Success(true, message: "User was succesfully registered ");
        }

        private static ApiUser Map(SignInRequest signInRequest, PreRegister preRegister)
        {
            return new ApiUser()
            {
                UserName = signInRequest.Username,
                Email = signInRequest.Email,
                FirstName = preRegister.FirstName,
                LastName = preRegister.LastName,
                PhoneNumber = preRegister.PhoneNumber,
            };
        }


    }

}

using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Models.PreRegister;
using RedSecure.Domain.Entities;
using RedSecure.Domain.Utils;
using RedSecure.Domain.Utils.Constants;
using RedSecure.Domain.Utils.Cryptography;
using RedSecure.Domain.Utils.Hash;

namespace RedSecure.Application.UseCases.PreRegistration
{
    public class PreRegistrationHandler : IPreRegistrationHandler
    {
        private readonly IPreRegisterRepository _preRegisterRepository;
     //   private readonly INotifyEventHandler _notifyEventHandler;

        public PreRegistrationHandler(IPreRegisterRepository preRegisterRepository/*, INotifyEventHandler notifyEventHandler*/)
        {
            _preRegisterRepository = preRegisterRepository;
     //       _notifyEventHandler = notifyEventHandler;
        }

        public async Task<ApiResponse<bool>> PreRegistrationAsync(PreRegisterDRequest registerRequest, CancellationToken cancellationToken = default)
        {
            var exists = await _preRegisterRepository.CheckIfExistsAsync(registerRequest.Email, registerRequest.UserName, cancellationToken);

            if(exists)
                return Response.Error(false, Constants.ErrorMessages.UserExistsPreregister, Constants.ErrorMessages.UserExists);

            var preRegister = Map(registerRequest);           

            var added = await _preRegisterRepository.PreRegisterAsync(preRegister, cancellationToken);
            if(!added)
                return Response.Error(false, Constants.ErrorMessages.PreregisterNotPossible);

           /* var eventSent = await _notifyEventHandler.SendPreRegisterEmail(preRegister.Email, preRegister.FirstName + " " + preRegister.LastName, preRegister.UserRegistrationSecretCode, cancellationToken);
            if (!eventSent)
                return Response.Error(false, Constants.ErrorMessages.PreregisterNotPossible);*/

            return Response.Success(true);
        }
       
        private static PreRegister Map(PreRegisterDRequest dto)
        {
            return new()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                PhoneNumber = dto.PhoneNumber,
                UserRegistrationSecretCode = CryptoService.HashUsername(dto.UserName + dto.Email)[..32],
                HashUserName = CryptoService.HashUsername(dto.UserName),
            };
        }       
    }
}

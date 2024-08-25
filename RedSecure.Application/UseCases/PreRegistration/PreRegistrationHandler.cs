using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Models.PreRegister;
using RedSecure.Domain.Entities;
using RedSecure.Domain.Templates;
using RedSecure.Domain.Utils;
using RedSecure.Domain.Utils.Constants;
using RedSecure.Domain.Utils.Hash;

namespace RedSecure.Application.UseCases.PreRegistration
{

    public class PreRegistrationHandler : IPreRegistrationHandler
    {
        private readonly IPreRegisterRepository _preRegisterRepository;
        private readonly IHashHandler _hashHandler;

        public PreRegistrationHandler(IPreRegisterRepository preRegisterRepository, IHashHandler hashHandler)
        {
            _preRegisterRepository = preRegisterRepository;
            _hashHandler = hashHandler;
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

            return Response.Success(true);

        }
       
        private PreRegister Map(PreRegisterDRequest dto)
        {
            return new()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                PhoneNumber = dto.PhoneNumber,
                UserRegistrationSecretCode = _hashHandler.HashSecret(dto.UserName + dto.Email)
            };
        }
   
       

        private string LoadHtmlTemplate(string Name, string CodeAccess, string CodeIV)
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(CodeAccess) || string.IsNullOrEmpty(CodeIV))
            {

                return "";

            }

            string htmlBody = HtmlTemplates.GetPreRegisterTemplate();

            return string.Format(htmlBody, Name, CodeAccess, CodeIV);
        }
    }




}

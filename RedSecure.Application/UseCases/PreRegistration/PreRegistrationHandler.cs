using Microsoft.Extensions.Options;
using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Models.PreRegister;
using RedSecure.Application.Models.Settings;
using RedSecure.Domain.Entities;
using RedSecure.Domain.Templates;
using RedSecure.Domain.Utils;
using RedSecure.Domain.Utils.Encryption;

namespace RedSecure.Application.UseCases.PreRegistration
{

    public class PreRegistrationHandler : IPreRegistrationHandler
    {
        private readonly IPreRegisterRepository _preRegisterRepository;
        private readonly CryptoSettings _cryptoSettings;

        public PreRegistrationHandler(IPreRegisterRepository preRegisterRepository,IOptions<CryptoSettings> cryptoSettings)
        {
            _cryptoSettings = cryptoSettings.Value;       
            _preRegisterRepository = preRegisterRepository;
        }

        public async Task<ApiResponse<bool>> PreRegistrationAsync(PreRegisterDto registerRequest, CancellationToken cancellationToken = default)
        {
            var exists = await _preRegisterRepository.CheckIfExistsAsync(registerRequest.Email, registerRequest.UserName, cancellationToken);

            if(exists)
                return Response.Error(false, "Already registered user", "User already exists in the platform.");

            var preRegister = Map(registerRequest);           

            var added = await _preRegisterRepository.PreRegisterAsync(preRegister, cancellationToken);

            if(!added)
                return Response.Error(false, "Register was not possible", "There was a problem while saving the user.");

            return Response.Success(true);

        }
       
        private PreRegister Map(PreRegisterDto dto)
        {
            return new()
            {
                Email = dto.Email,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                PhoneNumber = dto.PhoneNumber,
                UserRegistrationSecretCode = AddSecret(dto)
            };
        }
        private string AddSecret(PreRegisterDto dto)
        {
            return Encrypt.GenerateSha256Hash(_cryptoSettings.Salt, dto.UserName + dto.Email);
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

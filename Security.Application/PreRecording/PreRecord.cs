using Security.Application.InfrastructureContracts;
using Security.Application.Models;
using Security.Application.Models.Security;
using Security.Domain.Entities;
using Security.Domain.Templates;
using Security.Domain.Validations.HelpersExtensions;

namespace Security.Application.PreRecording
{
    public class PreRecord : IPreRecord
    {
        private readonly IPreRegisterRepository _preRegisterRepository;

        public PreRecord(IPreRegisterRepository preRegisterRepository)
        {
            _preRegisterRepository = preRegisterRepository;
        }

        public async Task<ApiResponse<bool>> PreRegisteringAsync(PreRegisterDto preRegister, CancellationToken token)
        {
            GlobalValidationsExtensions.CheckNull(preRegister);

            var response = new ApiResponse<bool>();            

            var exists = await _preRegisterRepository.CheckIfExistsAsync(preRegister.Email, preRegister.UserName, token);

            if (exists) {
                response.Response = false;
                response.Message = "user already exists in the platform";
            }

           // aqui tenemos que agregar esos datos la base de datos... 
            response.Response = true;
            response.Message = "Pre-registered user successfully";
            return response;
        }


        private string LoadHtmlTemplate(string Name, string CodeAccess, string CodeIV)
        {
            if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(CodeAccess) || string.IsNullOrEmpty(CodeIV)) {

                return "";
            
            }

            string htmlBody = HtmlTemplates.GetPreRegisterTemplate();

            return string.Format(htmlBody, Name, CodeAccess, CodeIV);
        }
        
    }
   
}

/*
 * primero debemos generar validacion de datos
 *verificar que no exista ni el email ni el suaurio en el sistema
 *generar el guardado del mismo en el sistema preregistro
 *generar las claves
 *guardar las claves
 *enviar el correo de confirmacion
 *enviar mensaje del controller
 * */
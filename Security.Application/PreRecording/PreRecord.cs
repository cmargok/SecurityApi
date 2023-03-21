using Security.Application.InfrastructureContracts;
using Security.Application.Models.Security;
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

        public async Task PreRegistering(PreRegisterDto preRegister, CancellationToken token)
        {
            GlobalValidationsExtensions.CheckNull(preRegister);

            var exists = await _preRegisterRepository.CheckIfExistsAsync(preRegister.Email, preRegister.UserName, token);

            if (!exists) { }
            
        }

        
    }

}

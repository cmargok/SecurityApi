using RedSecure.Application.Contracts;
using RedSecure.Application.Models.PreRegister;
using RedSecure.Application.Utils;

namespace RedSecure.Application.UseCases.PreRegistration
{
    public class PreRegistrationHandler : IPreRegistrationHandler
    {
        public async Task<ApiResponse<bool>> PreRegistrationAsync(PreRegisterDto preRegister, CancellationToken token)
        {
            var exists = false;

            if(exists)
                return Response.Error(false, "register already", "user already exists in the platform");

            return Response.Success(true);


        }
    }

}

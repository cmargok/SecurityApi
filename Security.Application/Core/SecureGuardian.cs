using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Security.Application.Models.Security;

namespace Security.Application.Core
{
    public class SecureGuardian : ISecureGuardian
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;

        public SecureGuardian(IMapper mapper, UserManager<ApiUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto apiuser)
        {
            var user = _mapper.Map<ApiUser>(apiuser);
            //AQUI DEBO IR A BUSCAR LA INFORMACION EN LA TABLA PRE REGISTRO PARA COMPLETAR LOS DATOS DEL USUARIO


            string hola = "cosa";

            var result = await _userManager.CreateAsync(user, apiuser.Password);

            if (result.Succeeded)
            { 
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }

        public void main() {

            Console.WriteLine(hola);



        }


    }
}

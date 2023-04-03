
using Microsoft.AspNetCore.Mvc;
using Security.Application.Core;
using Security.Application.Models.RegisterDtos;
using Security.Application.Models.Security;

namespace Security.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {


        private readonly ILogger<RegisterController> _logger;
        private readonly ISecureGuardian _Secure;

        public RegisterController(ILogger<RegisterController> logger, ISecureGuardian Secure)
        {
            _Secure = Secure;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> RegisterEndpoints(ApiUserDto apiUserDto, CancellationToken token)
        {

            //debemos crear en el _Secure un metodo para validar el token que generaremos con toda la informacoin necesaria para  poder registrarlo en el sistema
            //si todo se valida bien ahi si llamamos al metodo register para traer los datos dele preregistro y traerlos
            var errors = await _Secure.Register(apiUserDto);

            if (errors.Any())
            {
                var ErrorsRegisters = new ErrorRegister();
                foreach (var error in errors)
                {
                    ErrorsRegisters.AddError(error.Code, error.Description);
                }
                return BadRequest(ErrorsRegisters);
            }

            return Ok();//new UserResponseSuccess { RegisterStatus = "Success", User = apiUserDto.UserName });

        }


       
    }
}

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

            //debemos crear en el _Secure un metodo para validar el token que generaremos con toda la informacoin necesaria para
            //poder registrarlo en el sistema
            //si todo se valida bien ahi si llamamos al metodo register para traer los datos dele preregistro y traerlos
            var errors = await _Secure.Register(apiUserDto);

            //if (errors.Any())
            //{
            //    var ErrorsRegisters = new ErrorRegister();
            //    foreach (var error in errors)
            //    {
            //        ErrorsRegisters.AddError(error.Code, error.Description);
            //    }
            //    return BadRequest(ErrorsRegisters);
            //}
            //se debe procesar un mensaje de respuesta y un correo de confirmacion de registrro en el sistema.


            return Ok();//new UserResponseSuccess { RegisterStatus = "Success", User = apiUserDto.UserName });

        }


       //todo
       /*
        *falta generar un endpoint para logearse, que permita 3 re intentos, si no se bloquea por 24 horas.
        *este endpoint debe retornar un JWT de autorizacion para usar los demas sistemas..
        *
        *tambien falta terminar la implementacion del api de log, para poder generar la libreria yusarla en los diferentes sistemas. 
        *falta crear un api que sirva como  consumidor, ya que la libriera de log enviara los logs por rabbbitmq a la ocla descrita
        *el api de log consumira el log y lo guardara en algun servicio q se deestine para ello, la idea es usar elastichsearch o seq.
        *
        *falta terminar el api de notificaciones
        */

    }
}
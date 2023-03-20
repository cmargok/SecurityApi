
using Microsoft.AspNetCore.Mvc;
using Security.Application.Core;
using Security.Infrastructure.Models.RegisterDtos;
using Security.Infrastructure.Models.Security;

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

            return Ok(new UserResponseSuccess { RegisterStatus = "Success", User = apiUserDto.UserName });




        }
    }
}
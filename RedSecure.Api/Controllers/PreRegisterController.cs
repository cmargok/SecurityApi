using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSecure.Application.Contracts;
using RedSecure.Application.Models.PreRegister;
using RedSecure.Application.Models.Shared;

namespace RedSecure.Api.Controllers
{
    [ApiController]
    [Route("api/v1/pre-register")]
    public class PreRegisterController : ControllerBase
    {
        private readonly IPreRegistrationHandler _preRegistrationHandler;

        public PreRegisterController(IPreRegistrationHandler preRecord)
        {
            _preRegistrationHandler = preRecord;
        }

        [AllowAnonymous]
        [HttpPost("initRegistration")]
        public async Task<IActionResult> PreRegistrationAsync(PreRegisterDto preRegister, CancellationToken cancellationToken)
        {
            var result = await _preRegistrationHandler.PreRegistrationAsync(preRegister, cancellationToken);

            if (result.Error)
                return BadRequest(result);

            return Ok(result);

        }
    }

  


}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Models.PreRegister;
using RedSecure.Domain.Utils;

namespace RedSecure.Api.Controllers
{
    [ApiController]
    [Route("api/v1/pre-register")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PreRegisterController : ControllerBase
    {
        private readonly IPreRegistrationHandler _preRegistrationHandler;

        public PreRegisterController(IPreRegistrationHandler preRecord)
        {
            _preRegistrationHandler = preRecord;
        }

        [AllowAnonymous]
        [HttpPost("initRegistration")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]
 
        public async Task<IActionResult> PreRegistrationAsync([FromBody] PreRegisterDto preRegister, CancellationToken cancellationToken)
        {
            var result = await _preRegistrationHandler.PreRegistrationAsync(preRegister, cancellationToken);

            if (result.Error)
                return BadRequest(result);

            return Ok(result);
        }
    }

  


}

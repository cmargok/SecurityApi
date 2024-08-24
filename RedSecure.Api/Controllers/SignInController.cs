using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Models.PreRegister;
using RedSecure.Application.Models.SignIn;
using RedSecure.Domain.Utils;

namespace RedSecure.Api.Controllers
{
    [ApiController]
    [Route("api/v1/sign-in")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SignInController : ControllerBase
    {
        private readonly ISecureGuardian _secureGuardian;

        public SignInController(ISecureGuardian secureGuardian)
        {
            _secureGuardian = secureGuardian;
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> SignInAsync([FromBody] SignInRequest signInRequest, CancellationToken cancellationToken = default)
        {
            var result = await _secureGuardian.SignInAsync(signInRequest, cancellationToken);

            if (result.Error)
                return BadRequest(result);

            return Ok(result);
        }
    }

}

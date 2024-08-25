using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSecure.Application.Contracts.UseCases;
using RedSecure.Application.Models.SignUp;
using RedSecure.Domain.Utils;

namespace RedSecure.Api.Controllers
{
    [ApiController]
    [Route("api/v1/red-secure")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SignUpController : ControllerBase
    {
        private readonly ISignUpHandler _signUpHandler;

        public SignUpController(ISignUpHandler signUpHandler)
        {
            _signUpHandler = signUpHandler;
        }

        [AllowAnonymous]
        [HttpPost("signUp")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> SignUpAsync([FromBody] SignUpRequest signInRequest, CancellationToken cancellationToken = default)
        {
            var result = await _signUpHandler.SignUpAsync(signInRequest, cancellationToken);

            if (result.Error)
                return BadRequest(result);

            return Ok(result);
        }
    }

}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedSecure.Application.Contracts.Handlers;
using RedSecure.Application.Models.Login;
using RedSecure.Domain.Utils;

namespace RedSecure.Api.Controllers
{

    [ApiController]
    [Route("api/v1/red-secure")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class LoginController : ControllerBase 
    {
        private readonly ILoginHandler _loginHandler;
     
        public LoginController(ILoginHandler loginHandler)
        {
            _loginHandler = loginHandler;
        }


        /// <summary>
        /// Allows sign in or login into the system
        /// </summary>
        /// <param name="apiUserLoginDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("signIn")]
        [ProducesResponseType(typeof(ApiResponse<AuthResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest apiUserLoginDto, CancellationToken cancellationToken = default)
        {
            var result = await _loginHandler.LoginAsync(apiUserLoginDto, cancellationToken);

            if (result.Error)
                return BadRequest(result);

            return Ok(result);
        }
    }

}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Models.Security;
using Security.Application.PreRecording;

namespace Security.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PreRegisterController : ControllerBase
    {
        private readonly IPreRecord _preRecord;

        public PreRegisterController(IPreRecord preRecord)
        {
            _preRecord = preRecord;
        }

        [AllowAnonymous]
        [HttpPost("initRegistration")]
        public async Task<IActionResult> PreRegister(PreRegisterDto preRegister,CancellationToken cancellationToken)
        {
            var result = await _preRecord.PreRegisteringAsync(preRegister, cancellationToken);         

            return Ok(result);

        }
    }
}

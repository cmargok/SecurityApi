using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Models.Security;
using Security.Application.PreRecording;

namespace Security.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreRegisterController : ControllerBase
    {
        private readonly IPreRecord _preRecord;

        public PreRegisterController(IPreRecord preRecord)
        {
            _preRecord = preRecord;
        }

        [HttpPost("PreRegister")]
        public async Task<IActionResult> PreRegister(PreRegisterDto preRegister, CancellationToken token)
        {

            var result = _preRecord.PreRegistering(preRegister, token);


            return Ok();

        }
    }
}

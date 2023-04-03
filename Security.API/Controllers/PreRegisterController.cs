using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Models.Security;
using Security.Application.PreRecording;
using Security.Domain.Templates;
using Security.Infrastructure.Persistence.Migrations;

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

        [HttpPost("PreRegister")]
        public async Task<IActionResult> PreRegister(PreRegisterDto preRegister,CancellationToken token)
        {
            var result = await _preRecord.PreRegisteringAsync(preRegister, token);
         

            return Ok();

        }
    }
}

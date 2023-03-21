using Security.Application.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.PreRecording
{
    public interface IPreRecord
    {
        Task PreRegistering(PreRegisterDto preRegister, CancellationToken token);
    }

}

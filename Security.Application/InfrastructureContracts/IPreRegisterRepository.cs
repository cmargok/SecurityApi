using Security.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.InfrastructureContracts
{
    public interface IPreRegisterRepository
    {
        public Task<bool> PreRegisterAsync(PreRegister preRegister, CancellationToken cancellationToken);
        public Task<bool> CheckIfExistsAsync(string Email, string UserName, CancellationToken cancellationToken);
        public Task<PreRegister> GetRecordAsync(string Email, string UserName, CancellationToken cancellationToken);
    }
}

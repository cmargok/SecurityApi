using Microsoft.EntityFrameworkCore;
using Security.Application.InfrastructureContracts;
using Security.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Infrastructure.Persistence.Repositories
{
    public class PreRegisterRepository : IPreRegisterRepository
    {
        private readonly IdentityDBContext _dbContext;

        public PreRegisterRepository(IdentityDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfExistsAsync(string Email, string UserName, CancellationToken cancellationToken)
        {
           var exist = await _dbContext.PreRegisters.AnyAsync(r => r.UserName == UserName && r.Email == Email, cancellationToken);

            return exist;
        }

        public async Task<bool> PreRegisterAsync(PreRegister preRegister, CancellationToken cancellationToken)
        {
            await _dbContext.PreRegisters.AddAsync(preRegister, cancellationToken);

            var result = await _dbContext.SaveChangesAsync();

            if (result == 1) return true;

            return false;
        }


        public async Task<PreRegister> GetRecordAsync(string Email, string UserName, CancellationToken cancellationToken)
        {
            var preRegister = await _dbContext.PreRegisters.AsNoTracking().FirstOrDefaultAsync(r => r.UserName == UserName && r.Email == Email, cancellationToken);

            return preRegister!;
        }
    }
}

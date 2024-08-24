using Microsoft.EntityFrameworkCore;
using Security.Application.InfrastructureContracts;
using Security.Domain.Entities;

namespace Security.Infrastructure.Persistence.Repositories
{
    public class PreRegisterRepository : IPreRegisterRepository
    {
        private readonly IdentityDBContext _dbContext;

        public PreRegisterRepository(IdentityDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<PreRegister> GetRecordAsync(string Email, string UserName, CancellationToken cancellationToken)
        {
            var preRegister = await _dbContext.PreRegisters.AsNoTracking().FirstOrDefaultAsync(r => r.UserName == UserName && r.Email == Email, cancellationToken);

            return preRegister!;
        }
    }
}

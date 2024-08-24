using Microsoft.EntityFrameworkCore;
using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Domain.Entities;

namespace RedSecure.Infrastructure.Persistence.Repositories
{
    public class PreRegisterRepository : IPreRegisterRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public PreRegisterRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CheckIfExistsAsync(string Email, string UserName, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.PreRegisters.AnyAsync(r => r.UserName == UserName && r.Email == Email, cancellationToken);

            return result;
        }

        public async Task<bool> PreRegisterAsync(PreRegister preRegister, CancellationToken cancellationToken = default)
        {
            await _dbContext.PreRegisters.AddAsync(preRegister, cancellationToken);

            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            if (result is 1)
                return true;

            return false;
        }


        public async Task<PreRegister> GetRecordAsync(string Email, string UserName, CancellationToken cancellationToken = default)
        {
            var preRegister = await _dbContext.PreRegisters
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.UserName == UserName && r.Email == Email, cancellationToken);

            return preRegister!;
        }
    }
}

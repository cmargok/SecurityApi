using Microsoft.EntityFrameworkCore;
using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Domain.Entities;
using RedSecure.Domain.Utils.Constants;

namespace RedSecure.Infrastructure.Persistence.Repositories
{
    public class AuditRepository : IAuditRepository
    {
        private readonly ApplicationDBContext _context;
        public AuditRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddToken(TokenLog tokenLog)
        {
            _ = _context.Tokens.Add(tokenLog);
        }

        public async Task<int> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();

            return saved;
        }

        public async Task<int> BlockTokenAsync(string token, string blockIssuer, string blockReason)
        {
            var tokenEntity = await _context.Tokens.FirstOrDefaultAsync(c => c.Token == token);

            if (tokenEntity is not null)
            {
                var date = DateTime.Now;

                if (tokenEntity.IsBlocked == false || tokenEntity.IsBlocked == true && tokenEntity.BlockReason!.Equals(Constants.Reasons.BlockingTokenByJob) && tokenEntity.BlockedBy!.Equals(Constants.Issuers.BlockingJob))
                {
                    tokenEntity.IsBlocked = true;
                    tokenEntity.BlockDate = date;
                    tokenEntity.BlockedBy = blockIssuer;
                    tokenEntity.BlockReason = blockReason;

                    return await this.SaveAsync();
                }

                return 1;
            }
            return 0;
        }

        public async Task<int> BlockAllTokensAsync(string user, string blockIssuer, string blockReason)
        {
            var date = DateTime.Now;

            _ = await _context.Tokens
                .Where(c => c.UserEmail == user && c.IsBlocked == false)
                .ExecuteUpdateAsync(t => t
                    .SetProperty(p => p.IsBlocked, true)
                    .SetProperty(p => p.BlockDate, date)
                    .SetProperty(p => p.BlockedBy, blockIssuer)
                    .SetProperty(p => p.BlockReason, blockReason)
                    );

            return await SaveAsync();
        }



        public async Task BlockExpiredTokensByJobAsync<T>(string blockIssuer, string blockReason) where T : BlockandDateFields
        {
            var date = DateTime.Now;

            _ = await _context.Set<T>()
                .Where(token =>
                    token.IsBlocked == false && token.ExpireAt < date
                    )
                .ExecuteUpdateAsync(t => t
                    .SetProperty(p => p.IsBlocked, true)
                    .SetProperty(p => p.BlockDate, date)
                    .SetProperty(p => p.BlockedBy, blockIssuer)
                    .SetProperty(p => p.BlockReason, blockReason)
                    );
        }
    }
}

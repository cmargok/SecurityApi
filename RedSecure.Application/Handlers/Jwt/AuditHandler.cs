using Microsoft.Extensions.Options;
using RedSecure.Application.Contracts.Handlers;
using RedSecure.Application.Contracts.Infrastructure;
using RedSecure.Application.Models.Handlers.Jwt;
using RedSecure.Domain.Entities;
using RedSecure.Domain.Settings;
using RedSecure.Domain.Utils.Constants;

namespace RedSecure.Application.Handlers.Jwt
{
    public class AuditHandler : IAuditHandler
    {
        private readonly IAuditRepository _auditRepository;

        public AuditHandler(IAuditRepository auditRepository, IOptions<JwtSettings> settings)
        {
            _auditRepository = auditRepository;
        }

        public async Task<bool> AuditToken(JwtUserData user, TokenData tokenData)
        {
            LogToken(user, tokenData);

            return await SaveTokenAsync();

        }

        public async Task<bool> BlockTokenAsync(string token, string blockIssuer = Constants.Issuers.Internal, string blockReason = Constants.Reasons.TokenLoockedToPrevent)
            => await _auditRepository.BlockTokenAsync(token, blockIssuer, blockReason) > 0;

        public async Task<bool> BlockAllTokensAsync(string user, string blockIssuer = Constants.Issuers.Internal, string blockReason = Constants.Reasons.TokenLoockedToPrevent)
            => await _auditRepository.BlockAllTokensAsync(user, blockIssuer, blockReason) > 0;

        private void LogToken(JwtUserData user, TokenData tokenData)
        {
            var tokenLog = new TokenLog()
            {
                Id = tokenData.TokenId,
                UserId = user.Id,
                UserName = user.UserName!,
                UserRole = user.UserRole!,
                UserEmail = user.Email!,
                Token = tokenData.Token,
                CreatedAt = DateTime.Now,
                ExpireAt = tokenData.ExpireAt,
                IsBlocked = false,
            };
            _auditRepository.AddToken(tokenLog);
        }

        private async Task<bool> SaveTokenAsync() 
            => await _auditRepository.SaveAsync() > 0;

    }





}

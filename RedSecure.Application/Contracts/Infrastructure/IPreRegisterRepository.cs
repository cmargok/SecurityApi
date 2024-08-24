using RedSecure.Domain.Entities;

namespace RedSecure.Application.Contracts.Infrastructure
{
    public interface IPreRegisterRepository
    {
        public Task<bool> PreRegisterAsync(PreRegister preRegister, CancellationToken cancellationToken = default);
        public Task<bool> CheckIfExistsAsync(string Email, string UserName, CancellationToken cancellationToken = default);
        public Task<PreRegister> GetRecordAsync(string Email, string UserName, string secretCode, CancellationToken cancellationToken = default);
    }

}

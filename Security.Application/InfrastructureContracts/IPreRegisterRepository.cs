using Security.Domain.Entities;

namespace Security.Application.InfrastructureContracts
{
    public interface IPreRegisterRepository
    {
        public Task<PreRegister> GetRecordAsync(string Email, string UserName, CancellationToken cancellationToken);
    }
}

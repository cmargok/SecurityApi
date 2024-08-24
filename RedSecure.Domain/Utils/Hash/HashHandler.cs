using Microsoft.Extensions.Options;
using RedSecure.Domain.Settings;

namespace RedSecure.Domain.Utils.Hash
{

    public class HashHandler : IHashHandler
    {
        private readonly CryptoSettings _cryptoSettings;

        public HashHandler(IOptions<CryptoSettings> cryptoSettings)
        {
            _cryptoSettings = cryptoSettings.Value;
        }

        public string HashSecret(string value)
        {
            return Hashing.GenerateSha256Hash(_cryptoSettings.Salt, value)[..32];
        }

    }

    public interface IHashHandler
    {
        public string HashSecret(string value);
    }

}

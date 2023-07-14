using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Security.Infrastructure.IO;
using Azure.Security.KeyVault.Keys;

namespace Security.Infrastructure.Externals.Azure
{
    public static class SecretsManager
    {
       // private static readonly string SecurityDB = "SecurityDbConnection";
        public static async Task<string> GetConnectionString(bool IsDevelopment, string SecurityDB, string KeyVaultUrlEnviroment = "")
        {
            ArgumentException.ThrowIfNullOrEmpty(SecurityDB);

            if (IsDevelopment)
            {
                string path = "C:\\Secrets";

                var connectionString = IOReader.GetOneLineFromFile(path, SecurityDB + ".txt");

                return connectionString;

            }

            return await GetValueFromSeret(SecurityDB, KeyVaultUrlEnviroment);
            
        }

        private static async Task<string> GetValueFromSeret(string SecretName, string KeyVaultUrlEnviroment)
        {
            var keyVaultEndpoint = new Uri(KeyVaultUrlEnviroment!.ToString());
          //  var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("KeyVaultUrl")!.ToString());

            var _secretClient = new SecretClient(keyVaultEndpoint, new DefaultAzureCredential());

            var secret = await _secretClient.GetSecretAsync(SecretName);

            return secret.Value.Value;
        }

        public static async Task<string> GetkeyValue(string KeyName, string KeyVaultUrlEnviroment)
        {
            var keyVaultEndpoint = new Uri(KeyVaultUrlEnviroment!.ToString());

            var keyClient = new KeyClient(keyVaultEndpoint, new DefaultAzureCredential());

            var key = await keyClient.GetKeyAsync(KeyName);

            return key.Value.Key.ToString()!;

        }
    }


}
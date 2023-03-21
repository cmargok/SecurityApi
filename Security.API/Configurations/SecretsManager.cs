using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Security.Infrastructure.IO;

namespace Security.API.Configurations
{
    public static class SecretsManager
    {
        private static string SecurityDB = "SecurityDbConnection";
        public static async Task<string> GetConnectionString(bool IsDevelopment, IConfiguration config)
        {
            if (IsDevelopment)
            {
                string path = "C:\\Secrets";

                var connectionString = IOReader.GetOneLineFromFile(path, SecurityDB+".txt");

                return connectionString;

            }
            var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("KeyVaultUrl")!.ToString());  
            
            var _secretClient = new SecretClient(keyVaultEndpoint, new DefaultAzureCredential());

            var secret = await _secretClient.GetSecretAsync(SecurityDB);

            Console.WriteLine( secret.Value.Value );
            return secret.Value.Value;
        }
    }
}
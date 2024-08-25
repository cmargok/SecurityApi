namespace RedSecure.Domain.Settings
{
    public class CryptoSettings
    {
        public required string Salt { get; set; }
    }

    public class JwtSettings
    {
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required string SecureKey { get; set; }
        public required TokenSettings Token { get; set; }
    }

    public class TokenSettings
    {
        public required int ExpirationInMinutes { get; set; }
    }


}

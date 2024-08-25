namespace RedSecure.Application.Models.Login
{
    public class AuthTokenResponse
    {
        public string JwtToken { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Scope { get; set; } = string.Empty;
    }

}

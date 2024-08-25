namespace RedSecure.Application.Models.Login
{
    public class AuthResponse
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public AuthTokenResponse Auth { get; set; } = new();

    }

}

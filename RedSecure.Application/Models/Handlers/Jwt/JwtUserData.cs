using RedSecure.Domain.Utils.Constants;

namespace RedSecure.Application.Models.Handlers.Jwt
{
    public sealed class JwtUserData
    {
        public string Id { get; set; } = string.Empty; //audit // lo saco de la bd
        public string? UserName { get; set; } //bd
        public string? Email { get; set; } // viene
        public string UserRole { get; set; } = string.Empty;// lo saco de la bd
    }
    public sealed class TokenData
    {
        public Guid TokenId { get; set; } = Guid.NewGuid();
        public DateTime ExpireAt { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Type { get; set; } = Constants.TokenParameters.TokenType;
        public string Scope { get; set; } = Constants.TokenParameters.Scope;
    }
}

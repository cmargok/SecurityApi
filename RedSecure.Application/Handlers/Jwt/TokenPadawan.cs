using Microsoft.IdentityModel.Tokens;
using RedSecure.Application.Models.Handlers.Jwt;
using RedSecure.Domain.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RedSecure.Application.Handlers.Jwt
{
    public class TokenPadawan
    {
        private readonly JwtSettings _settings;
        public TokenPadawan(JwtSettings settings)
        {
            _settings = settings;
        }

        public TokenData CreateToken(JwtUserData user)
        {
            var tokenData = new TokenData
            {
                ExpireAt = DateTime.Now.AddMinutes(_settings.Token.ExpirationInMinutes)
            };

            var tokenDef = BuildToken(BuildTokenClaims(user, tokenData), CreateSigningCredentials());

            var tokenHandler = new JwtSecurityTokenHandler();
            tokenData.Token = tokenHandler.WriteToken(tokenDef);

            return tokenData;
        }

        private static JwtSecurityToken BuildToken(List<Claim> claims, SigningCredentials signingCredentials)
         => new(
                claims: claims,
                signingCredentials: signingCredentials
                );

        private List<Claim> BuildTokenClaims(JwtUserData user, TokenData tokenData, JsonSerializerOptions options = null!)
        {
            options ??= new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var roles = JsonSerializer.Serialize(new RolesClaim()
            {
                Roles = [user.UserRole],
                Scope = tokenData.Scope,
            }, options);

            return [
                new(JwtRegisteredClaimNames.Exp, EpochTime.GetIntDate(tokenData.ExpireAt.ToUniversalTime()).ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString()),
                new(JwtRegisteredClaimNames.Jti, tokenData.TokenId.ToString()),
                new(JwtRegisteredClaimNames.Iss, _settings.Issuer),
                new(JwtRegisteredClaimNames.Aud, _settings.Audience),
                new(JwtRegisteredClaimNames.Typ, tokenData.Type),
                new(JwtRegisteredClaimNames.Email, user.Email!),
                new("resource_access", roles, JsonClaimValueTypes.Json),
                ];
        }

        private SigningCredentials CreateSigningCredentials()
        {
            var encodedKey = Encoding.UTF8.GetBytes(_settings.SecureKey);

            return new SigningCredentials(new SymmetricSecurityKey(encodedKey), SecurityAlgorithms.HmacSha256);
        }

        private record RolesClaim
        {
            public List<string> Roles { get; set; } = [];
            public string? Scope { get; set; }
        }
    }





}

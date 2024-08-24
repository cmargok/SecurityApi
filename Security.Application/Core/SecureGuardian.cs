using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Security.Application.Models.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security.Application.Core
{
    public class SecureGuardian 
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly IMapper _mapper;

        public SecureGuardian(IMapper mapper, UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<AuthResponse> Login(AuthRequest request) 
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
            {
                throw new Exception("usuario no existe");
            }

            var resultLogin = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

            if(!resultLogin.Succeeded) 
            {
                throw new Exception("credenciales incorrectas");

            }

            var response = new AuthResponse()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token =  ""//aqui llamamos al generador de token    
            
            };

            return response;
        }


        private async Task<string> GenerateToken(ApiUser user) 
        {
            var userClaims = await _userManager.GetClaimsAsync(user);

            var roles =  await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var Myclaims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id)
            }.Union(userClaims).Union(roleClaims);

            //reemplazar esasymetric key desde el appsetingso enviroment
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( "chinguiritoChatarra"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                  issuer: "telefonica.com.co",//reemplazar dsde appsettings
                  audience: "Public",//reemplazar dsde appsettings
                  expires: DateTime.UtcNow.AddMinutes(50),//reemplazar dsde appsettings
                  claims: Myclaims,
                  signingCredentials: credentials
              );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

    }
    public class AuthRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class AuthResponse
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
    public class CustomClaimTypes
    {
        public const string Uid = "uid";
    }
}

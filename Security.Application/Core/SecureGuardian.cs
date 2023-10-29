using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Security.Application.Models.Security;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security.Application.Core
{
    public class SecureGuardian : ISecureGuardian
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


       // public async Task<IEnumerable<IdentityError>> Register(ApiUserDto apiuser)
            public async Task<object> Register(ApiUserDto apiuser)
        {
        
            //AQUI DEBO IR A BUSCAR LA INFORMACION EN LA TABLA PRE REGISTRO PARA COMPLETAR LOS DATOS DEL USUARIO



            var existingUser = await _userManager.FindByNameAsync(apiuser.Username);

            if (existingUser != null)
            {
                throw new Exception("usuario ya existe");
            }


            var existingEmail= await _userManager.FindByEmailAsync(apiuser.Email);

            if (existingEmail != null)
            {
                throw new Exception("email ya existe");
            }

            //como viene un secretcode

            //aqui debemos verificar si es e mismo. que esta en base de datos,


            //aqui mapeamos os dato sque legan con los deben registrarse


            var user = _mapper.Map<ApiUser>(apiuser);


            var result = await _userManager.CreateAsync(user, apiuser.Password);

            if (!result.Succeeded)
            {
                //throw new Exception("el suaurio no pudo ser creado");
                return result.Errors;
            }

            await _userManager.AddToRoleAsync(user, "User");

            //determinamos que vamos a devolver para ocnfirmar que ellogin creado
            //definir si enviamos toquen al registrarse, que no creo     
            return true;
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

using Microsoft.AspNetCore.Identity;
using RedSecure.Application.Contracts.Handlers;
using RedSecure.Application.Models.Security;

namespace RedSecure.Application.Handlers
{
    public class IdentityHandler : IIdentityHandler
    {

        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;

        public IdentityHandler(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(bool created, string errors)> CreateAsync(ApiUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {                
                return (false, "there were some errores.")!;
            }

            await _userManager.AddToRoleAsync(user, "User");

            return (true, "");
        }


        public async Task<bool> VerifyIfUserIsRegisteredAready(string user, string email)
        {
            var exists = await _userManager.FindByNameAsync(user);

            if (exists != null)
                return true;

            var existsEmail = await GetUserAsync(email);

            if (existsEmail != null)
                return true;

            return false;
        }

        public async Task<ApiUser?> GetUserAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);           
        }

        public async Task<List<string>> GetRolesAsync(ApiUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return roles.ToList();
        }
        public async Task<(bool status, string result)> LogInAsync(string user, string pass)
        {           
            var result = await _signInManager.PasswordSignInAsync(user, pass, false, false);

            if (result.Succeeded)
                return (true,"Success");

            if (result.IsLockedOut)
                return (false, "Blocked");

            return (false, "sign in invalid");

        }

    }
}

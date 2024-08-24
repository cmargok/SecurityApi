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
                var errors = result.Errors.ToString();
                return (false, errors)!;
            }

            await _userManager.AddToRoleAsync(user, "User");

            return (true, "");
        }


        public async Task<bool> VerifyIfUserIsRegisteredAready(string user, string email)
        {
            var exists = await _userManager.FindByNameAsync(user);

            if (exists != null)
                return true;

            var existsEmail = await _userManager.FindByEmailAsync(email);

            if (existsEmail != null)
                return true;

            return false;
        }
    }

}

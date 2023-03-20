using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Security.Infrastructure.Models.Security;
using Security.Infrastructure.Persistence.Configurations.Security;

namespace Security.Application.Core
{
    public class SecureGuardian : ISecureGuardian
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IMapper _mapper;

        public SecureGuardian(IMapper mapper, UserManager<ApiUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

       
        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto apiuser)
        {
            var user = _mapper.Map<ApiUser>(apiuser);


            var result = await _userManager.CreateAsync(user, apiuser.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }


    }
}

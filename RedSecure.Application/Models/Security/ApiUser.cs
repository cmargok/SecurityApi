
using Microsoft.AspNetCore.Identity;

namespace RedSecure.Application.Models.Security
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? RegisterAt { get; set; }
        public string NoHashedUserName { get; set; } = string.Empty;
        public string UserSalt { get; set; } = string.Empty;

    }
}

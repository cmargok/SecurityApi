
using Microsoft.AspNetCore.Identity;

namespace RedSecure.Application.Models.Security
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

    }
}

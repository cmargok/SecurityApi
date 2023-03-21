
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Security.Application.Models.Security
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [StringLength(32)]
        public string CodeIV { get; set; }

        [StringLength(128)]
        public string AccessCode { get; set; }

    }
}

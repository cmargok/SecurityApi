
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Security.Application.Models.Security
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;



    }
}

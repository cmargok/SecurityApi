using RedSecure.Domain.Validations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RedSecure.Application.Models.Shared
{
    public class ApiUserLoginDto
    {

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }

    }
}

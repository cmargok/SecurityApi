using RedSecure.Application.Validations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RedSecure.Application.Models.Shared
{
    public class ApiUserLoginDto
    {

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [PasswordPolicy]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        public required string Password { get; set; }

    }
}

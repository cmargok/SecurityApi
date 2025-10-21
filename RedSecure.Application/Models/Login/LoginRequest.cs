using RedSecure.Domain.Validations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RedSecure.Application.Models.Login
{
    public class LoginRequest
    {

        [Required]
        [MinLength(2)]
        public required string UserName { get; set; }

        [Required]
        [PasswordPolicy]
        [MinLength(6)]
        public required string Password { get; set; }

    }
}

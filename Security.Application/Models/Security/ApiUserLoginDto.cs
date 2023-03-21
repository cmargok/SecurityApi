using Security.Domain.Validations.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Security.Application.Models.Security
{
    public class ApiUserLoginDto
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPolity]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Security.Application.Models.Security
{
    public class ApiUserLoginDto
    {

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        public required string Password { get; set; }

    }
}

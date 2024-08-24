using RedSecure.Application.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace RedSecure.Application.Models.SignIn
{
    public class SignInRequest : ApiUserLoginDto
    {
        [Required]
        [StringLength(32)]
        public string SecretCode { get; set; } = string.Empty;


        [Required]
        [MinLength(4)]
        public string Username { get; set; } = string.Empty;

    }
}

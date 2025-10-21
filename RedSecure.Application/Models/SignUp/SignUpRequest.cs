using RedSecure.Application.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace RedSecure.Application.Models.SignUp
{
    public class SignUpRequest : ApiUserLoginDto
    {
        [Required]
        [StringLength(32)]
        public string SecretCode { get; set; } = string.Empty;


        [Required]
        [MinLength(4)]
        public string Username { get; set; } = string.Empty;

    }


}

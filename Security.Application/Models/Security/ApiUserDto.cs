using System.ComponentModel.DataAnnotations;

namespace Security.Application.Models.Security
{
    public class ApiUserDto : ApiUserLoginDto
    {
        [Required]
        [StringLength(32)]
        public string SecretCode { get; set; } = string.Empty;


        [Required]
        public string Username { get; set; } = string.Empty;

    }
}

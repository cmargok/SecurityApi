using System.ComponentModel.DataAnnotations;

namespace Security.Application.Models.Security
{
    public class ApiUserDto : ApiUserLoginDto
    {
        [Required]
        [StringLength(32)]
        public string CodeIV { get; set; }

        [Required]
        [StringLength(128)]
        public string AccessCode { get; set; }

    }
}

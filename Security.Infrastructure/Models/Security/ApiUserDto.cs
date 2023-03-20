using System.ComponentModel.DataAnnotations;

namespace Security.Infrastructure.Models.Security
{
    public class ApiUserDto : ApiUserLoginDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(32)]
        public string CodeIV { get; set; }

        [Required]
        [StringLength(128)]
        public string AccessCode { get; set; }

        public string PhoneNumber { get; set; }

    }
}

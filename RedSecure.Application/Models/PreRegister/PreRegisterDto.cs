using RedSecure.Application.Validations.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RedSecure.Application.Models.PreRegister
{
    public class PreRegisterDto : ApiUserLoginDto
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public required string UserName { get; set; }

        [JustNumbers]
        public required string PhoneNumber { get; set; }

    }
}

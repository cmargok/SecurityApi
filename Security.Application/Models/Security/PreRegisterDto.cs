using Security.Domain.Validations.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Security.Application.Models.Security
{
    public class PreRegisterDto : ApiUserLoginDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [JustNumbers]
        public string PhoneNumber { get; set; }

    }
}

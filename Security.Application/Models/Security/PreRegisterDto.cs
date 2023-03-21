using Security.Domain.Validations.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Security.Application.Models.Security
{
    public class PreRegisterDto : ApiUserLoginDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [JustNumbers]
        public string PhoneNumber { get; set; }

    }
}

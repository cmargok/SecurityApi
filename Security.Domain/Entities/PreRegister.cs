using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security.Domain.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Table("PreRegister")]
    public class PreRegister
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]       
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [Required]
        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(32)]
        public string UserRegistrationSecretCode { get; set; }
    }
}

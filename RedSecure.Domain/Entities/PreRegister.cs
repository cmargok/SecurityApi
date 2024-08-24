using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable enable
namespace RedSecure.Domain.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    [Table(name:"PreRegister", Schema = "dbo")]
    public class PreRegister
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Column("LastName")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        [Column("UserName")]
        public string UserName { get; set; } = string.Empty;

        [StringLength(12)]
        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(450)]
        [Column("Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        [Column("Password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column("IsRegistered")]
        public bool IsRegistered { get; set; }

        [Required]
        [StringLength(32)]
        [Column("UserRegistrationSecretCode")]
        public string UserRegistrationSecretCode { get; set; } = string.Empty;
    }
}
#nullable disable

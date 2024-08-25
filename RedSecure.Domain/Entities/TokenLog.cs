using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RedSecure.Domain.Entities
{
    [Table(name: "AUDIT_TOKEN", Schema = "logAudit")]
    public class TokenLog : BlockandDateFields
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Required]
        [Column("USER_ID")]
        [StringLength(50)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Column("USER_NAME")]
        [StringLength(150)]
        public string UserName { get; set; } = string.Empty;

        [Column("USER_ROLE")]
        [StringLength(50)]
        public string? UserRole { get; set; }

        [Required]
        [Column("USER_EMAIL")]
        [StringLength(50)]
        public string UserEmail { get; set; } = string.Empty;

        [Required]
        [Column("TOKEN")]
        [StringLength(550)]

        public string Token { get; set; } = string.Empty;

        [Required]
        [Column("CREATED_AT")]
        public DateTime CreatedAt { get; set; }
    }
}

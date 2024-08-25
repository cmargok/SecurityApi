using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable enable
namespace RedSecure.Domain.Entities
{  
    public abstract class BlockandDateFields
    {
        [Required]
        [Column("EXPIRE_AT")]
        public DateTime ExpireAt { get; set; }

        [Required]
        [Column("IS_BLOCKED")]
        public bool? IsBlocked { get; set; } = false;

        [Column("BLOCKED_BY")]
        [StringLength(100)]
        public string? BlockedBy { get; set; }

        [Column("BLOCK_DATE")]
        public DateTime? BlockDate { get; set; }

        [Column("BLOCK_REASON")]
        [StringLength(550)]
        public string? BlockReason { get; set; }
    }
}
#nullable disable

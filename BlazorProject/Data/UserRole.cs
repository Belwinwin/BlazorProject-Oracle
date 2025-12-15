using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Data
{
    [Table("USERROLES")]
    public class UserRole
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        
        [Required]
        [Column("USERID")]
        public string UserId { get; set; }
        
        [Required]
        [Column("ROLEID")]
        public int RoleId { get; set; }
        
        [Column("ASSIGNEDAT")]
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Data
{
    [Table("ROLES")]
    public class Role
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        
        [Required]
        [Column("NAME")]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Column("DESCRIPTION")]
        [MaxLength(200)]
        public string? Description { get; set; }
        
        [Column("CREATEDAT")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
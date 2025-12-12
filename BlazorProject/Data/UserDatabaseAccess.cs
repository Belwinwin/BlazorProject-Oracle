using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Data
{
    [Table("USERDATABASEACCESS")]
    public class UserDatabaseAccess
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        
        [Required]
        [Column("USERID")]
        public string UserId { get; set; }
        
        [Required]
        [Column("DATABASENAME")]
        public string DatabaseName { get; set; }
        
        [Column("HASACCESS")]
        public bool HasAccess { get; set; } = true;
        
        [Column("CREATEDAT")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
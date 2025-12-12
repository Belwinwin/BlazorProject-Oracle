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
        public int HasAccess { get; set; } = 1;
        
        [Column("CREATEDAT")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Data
{
    [Table("REGISTRATIONDETAILS")]
    public class RegistrationDetails
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        
        [Required]
        [Column("USERID")]
        public string UserId { get; set; }
        
        [Required]
        [Column("USERNAME")]
        public string UserName { get; set; }
        
        [Required]
        [Column("EMAIL")]
        public string Email { get; set; }
        
        [Required]
        [Column("PASSWORDHASH")]
        public string PasswordHash { get; set; }
        
        [Column("CREATEDAT")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
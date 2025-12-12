using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Data
{
    [Table("EMPLOYEEDETAILS")]
    public class Employee
    {
        [Column("ID")]
        public int Id { get; set; }
        
        [Column("NAME")]
        public string Name { get; set; }

        [Column("EMAIL")]
        public string? email { get; set; }

        [Column("ROLE")]
        public string? role { get; set; }

        [Column("PHONENUMBER")]
        public long? PhoneNumber { get; set; }
    }
}

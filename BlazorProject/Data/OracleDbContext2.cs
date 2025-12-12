using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Data
{
    public class OracleDbContext2 : DbContext
    {
        public OracleDbContext2(DbContextOptions<OracleDbContext2> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Employee>().ToTable("EMPLOYEEDETAILS");
        }
    }
}
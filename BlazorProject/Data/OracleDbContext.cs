using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "John Smith" },
                new Employee { Id = 2, Name = "Sarah Johnson" },
                new Employee { Id = 3, Name = "Michael Brown" }
            );
        }
    }
}

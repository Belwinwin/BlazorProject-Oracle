using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RegistrationDetails> RegistrationDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().ToTable("EMPLOYEEDETAILS").HasData(
                new Employee { Id = 1, Name = "John Smith" },
                new Employee { Id = 2, Name = "Sarah Johnson" },
                new Employee { Id = 3, Name = "Michael Brown" }
            );
        }
    }
}

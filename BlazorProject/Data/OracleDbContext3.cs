using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Data
{
    public class OracleDbContext3 : DbContext
    {
        public OracleDbContext3(DbContextOptions<OracleDbContext3> options) : base(options)
        {
        }

        public DbSet<RegistrationDetails> RegistrationDetails { get; set; }
        public DbSet<UserDatabaseAccess> UserDatabaseAccess { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<RegistrationDetails>().ToTable("REGISTRATIONDETAILS");
            modelBuilder.Entity<UserDatabaseAccess>().ToTable("USERDATABASEACCESS");
        }
    }
}
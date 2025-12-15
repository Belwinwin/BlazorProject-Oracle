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
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<RegistrationDetails>().ToTable("REGISTRATIONDETAILS");
            modelBuilder.Entity<UserDatabaseAccess>().ToTable("USERDATABASEACCESS");
            modelBuilder.Entity<Role>().ToTable("ROLES");
            modelBuilder.Entity<UserRole>().ToTable("USERROLES");

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", Description = "Full system access", CreatedAt = new DateTime(2024, 12, 15) },
                new Role { Id = 2, Name = "Manager", Description = "Management level access", CreatedAt = new DateTime(2024, 12, 15) },
                new Role { Id = 3, Name = "User", Description = "Standard user access", CreatedAt = new DateTime(2024, 12, 15) }
            );
        }
    }
}
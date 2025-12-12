using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlazorProject.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            var connectionString = "User Id=c##belwin;Password=belwin123;Data Source=192.168.2.210:1521/orcl;Connection Timeout=30;";
            
            optionsBuilder.UseOracle(connectionString);
            
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
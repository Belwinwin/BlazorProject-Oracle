using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlazorProject.Data
{
    public class OracleDbContextFactory : IDesignTimeDbContextFactory<OracleDbContext>
    {
        public OracleDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OracleDbContext>();
            
            // Use the Oracle connection string from appsettings.json
            var connectionString = "User Id=c##belwin;Password=belwin123;Data Source=192.168.2.210:1521/orcl;Connection Timeout=30;";
            
            optionsBuilder.UseOracle(connectionString);
            
            return new OracleDbContext(optionsBuilder.Options);
        }
    }
}
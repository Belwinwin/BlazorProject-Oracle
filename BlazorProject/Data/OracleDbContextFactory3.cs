using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BlazorProject.Data
{
    public class OracleDbContextFactory3 : IDesignTimeDbContextFactory<OracleDbContext3>
    {
        public OracleDbContext3 CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OracleDbContext3>();
            optionsBuilder.UseOracle("User Id=hr2;Password=hr2;Data Source=192.168.2.38:1522/xepdb1;Connection Timeout=30;");

            return new OracleDbContext3(optionsBuilder.Options);
        }
    }
}
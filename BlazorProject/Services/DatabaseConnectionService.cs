using Microsoft.Extensions.Configuration;

namespace BlazorProject.Services
{
    public class DatabaseConnectionService
    {
        private readonly IConfiguration _configuration;
        public string SelectedConnection { get; private set; } = "OracleConnection";

        public DatabaseConnectionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString(SelectedConnection) 
                   ?? throw new InvalidOperationException($"{SelectedConnection} not found");
        }

        public void SetConnection(string connectionName)
        {
            SelectedConnection = connectionName;
        }

        public string GetCurrentConnectionName()
        {
            return SelectedConnection == "OracleConnection" ? "Option A (c##belwin)" : "Option B (hr)";
        }
    }
}
using Oracle.ManagedDataAccess.Client;

namespace BlazorProject
{
    public static class OracleConnectionTest
    {
        public static void TestOracleConnections(IConfiguration configuration)
        {
            Console.WriteLine("=== Oracle Connection Test ===");
            
            // Test different connection string formats
            var connectionStrings = new Dictionary<string, string>
            {
                ["Current Config"] = configuration.GetConnectionString("OracleConnection") ?? "",
                ["Format 1 - EZ Connect"] = "User Id=c##belwin;Password=belwin123;Data Source=192.168.2.210:1521/orcl;Connection Timeout=30;",
                ["Format 2 - TNS Format"] = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.210)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=c##belwin;Password=belwin123;Connection Timeout=30;",
                ["Format 3 - SID Format"] = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.210)(PORT=1521))(CONNECT_DATA=(SID=orcl)));User Id=c##belwin;Password=belwin123;Connection Timeout=30;",
                ["Format 4 - Alternative Order"] = "Data Source=192.168.2.210:1521/orcl;User Id=c##belwin;Password=belwin123;Connection Timeout=30;"
            };

            foreach (var (name, connStr) in connectionStrings)
            {
                Console.WriteLine($"\nTesting {name}:");
                Console.WriteLine($"Connection String: {connStr}");
                
                try
                {
                    using var connection = new OracleConnection(connStr);
                    connection.Open();
                    
                    // Test a simple query
                    using var command = new OracleCommand("SELECT SYSDATE FROM DUAL", connection);
                    var result = command.ExecuteScalar();
                    
                    Console.WriteLine($"✅ SUCCESS - Server Time: {result}");
                    Console.WriteLine($"Oracle Version: {connection.ServerVersion}");
                    
                    // This connection works, update the configuration
                    UpdateConnectionString(configuration, connStr);
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ FAILED - {ex.Message}");
                }
            }
            
            Console.WriteLine("\n⚠️ All connection attempts failed. Please check:");
            Console.WriteLine("1. Oracle server is running");
            Console.WriteLine("2. Port 1521 is accessible");
            Console.WriteLine("3. Service name/SID is correct");
            Console.WriteLine("4. Username and password are correct");
            Console.WriteLine("5. Oracle client is properly installed");
        }
        
        private static void UpdateConnectionString(IConfiguration configuration, string workingConnectionString)
        {
            Console.WriteLine($"\n✅ Found working connection string: {workingConnectionString}");
            // Note: This is for testing only. In production, update appsettings.json manually
        }
    }
}
using BlazorProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Services
{
    public interface IUserAccessService
    {
        Task<List<string>> GetUserAccessibleDatabasesAsync(string userId);
        Task GrantDatabaseAccessAsync(string userId, string databaseName);
        Task<List<UserDatabaseAccess>> GetAllUserAccessAsync();

    }

    public class UserAccessService : IUserAccessService
    {
        private readonly OracleDbContext3 _context;

        public UserAccessService(OracleDbContext3 context)
        {
            _context = context;
        }

        public async Task<List<string>> GetUserAccessibleDatabasesAsync(string userId)
        {
            try
            {
                var connection = _context.Database.GetDbConnection();
                await connection.OpenAsync();
                
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT DISTINCT DATABASENAME FROM USERDATABASEACCESS WHERE USERID = '" + userId + "' AND HASACCESS = 1";
                
                var databases = new List<string>();
                using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    databases.Add(reader.GetString(0));
                }
                
                await connection.CloseAsync();
                return databases;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<string>();
            }
        }

        public async Task GrantDatabaseAccessAsync(string userId, string databaseName)
        {
            var existingAccess = await _context.UserDatabaseAccess
                .FirstOrDefaultAsync(u => u.UserId == userId && u.DatabaseName == databaseName);

            if (existingAccess == null)
            {
                _context.UserDatabaseAccess.Add(new UserDatabaseAccess
                {
                    UserId = userId,
                    DatabaseName = databaseName,
                    HasAccess = 1
                });
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UserDatabaseAccess>> GetAllUserAccessAsync()
        {
            var results = new List<UserDatabaseAccess>();
            try
            {
                var connection = _context.Database.GetDbConnection();
                
                // Test connection
                var canConnect = await _context.Database.CanConnectAsync();
                if (!canConnect)
                {
                    results.Add(new UserDatabaseAccess { UserId = "ERROR", DatabaseName = "Cannot connect to database", HasAccess = 0 });
                    return results;
                }
                
                await connection.OpenAsync();
                
                // Check if table exists
                using var checkCommand = connection.CreateCommand();
                checkCommand.CommandText = "SELECT COUNT(*) FROM USER_TABLES WHERE TABLE_NAME = 'USERDATABASEACCESS'";
                var tableExists = Convert.ToInt32(await checkCommand.ExecuteScalarAsync()) > 0;
                
                if (!tableExists)
                {
                    results.Add(new UserDatabaseAccess { UserId = "ERROR", DatabaseName = "Table USERDATABASEACCESS does not exist", HasAccess = 0 });
                    await connection.CloseAsync();
                    return results;
                }
                
                // Get current user
                using var userCommand = connection.CreateCommand();
                userCommand.CommandText = "SELECT USER FROM DUAL";
                var currentUser = await userCommand.ExecuteScalarAsync();
                
                // Count records in table
                using var countCommand = connection.CreateCommand();
                countCommand.CommandText = "SELECT COUNT(*) FROM USERDATABASEACCESS";
                var recordCount = Convert.ToInt32(await countCommand.ExecuteScalarAsync());
                

                
                // Get actual data
                using var command = connection.CreateCommand();
                command.CommandText = "SELECT USERID, DATABASENAME, HASACCESS FROM USERDATABASEACCESS";
                
                using var reader = await command.ExecuteReaderAsync();
                
                while (await reader.ReadAsync())
                {
                    results.Add(new UserDatabaseAccess
                    {
                        UserId = reader.GetString(0),
                        DatabaseName = reader.GetString(1),
                        HasAccess = reader.GetInt32(2)
                    });
                }
                
                await connection.CloseAsync();
                return results;
            }
            catch (Exception ex)
            {
                results.Add(new UserDatabaseAccess { UserId = "ERROR", DatabaseName = ex.Message, HasAccess = 0 });
                return results;
            }
        }
    }
}
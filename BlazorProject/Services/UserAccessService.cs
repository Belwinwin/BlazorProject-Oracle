using BlazorProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Services
{
    public interface IUserAccessService
    {
        Task<List<string>> GetUserAccessibleDatabasesAsync(string userId);


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


    }
}
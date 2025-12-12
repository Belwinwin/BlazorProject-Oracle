using BlazorProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Services
{
    public interface IUserAccessService
    {
        Task<List<string>> GetUserAccessibleDatabasesAsync(string userId);
        Task GrantDatabaseAccessAsync(string userId, string databaseName);
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
            return await _context.UserDatabaseAccess
                .Where(u => u.UserId == userId && u.HasAccess)
                .Select(u => u.DatabaseName)
                .ToListAsync();
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
                    HasAccess = true
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
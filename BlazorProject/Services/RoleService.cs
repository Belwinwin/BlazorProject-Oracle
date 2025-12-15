using BlazorProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorProject.Services
{
    public class RoleService : IRoleService
    {
        private readonly OracleDbContext3 _context;

        public RoleService(OracleDbContext3 context)
        {
            _context = context;
        }

        public async Task<List<string>> GetUserRolesAsync(string userId)
        {
            return await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .Select(ur => ur.Role.Name)
                .ToListAsync();
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
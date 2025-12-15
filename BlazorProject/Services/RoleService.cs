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

        public async Task<bool> AssignRoleAsync(string userId, string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
            if (role == null) return false;

            var existingUserRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == role.Id);
            
            if (existingUserRole != null) return true;

            _context.UserRoles.Add(new UserRole
            {
                UserId = userId,
                RoleId = role.Id
            });

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveRoleAsync(string userId, string roleName)
        {
            var userRole = await _context.UserRoles
                .Include(ur => ur.Role)
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.Role.Name == roleName);

            if (userRole == null) return false;

            _context.UserRoles.Remove(userRole);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsInRoleAsync(string userId, string roleName)
        {
            return await _context.UserRoles
                .Include(ur => ur.Role)
                .AnyAsync(ur => ur.UserId == userId && ur.Role.Name == roleName);
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
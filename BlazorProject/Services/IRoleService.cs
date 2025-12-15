using BlazorProject.Data;

namespace BlazorProject.Services
{
    public interface IRoleService
    {
        Task<List<string>> GetUserRolesAsync(string userId);
        Task<bool> AssignRoleAsync(string userId, string roleName);
        Task<bool> RemoveRoleAsync(string userId, string roleName);
        Task<bool> IsInRoleAsync(string userId, string roleName);
        Task<List<Role>> GetAllRolesAsync();
    }
}
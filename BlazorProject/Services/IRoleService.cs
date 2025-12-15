using BlazorProject.Data;

namespace BlazorProject.Services
{
    public interface IRoleService
    {
        Task<List<string>> GetUserRolesAsync(string userId);
        Task<List<Role>> GetAllRolesAsync();
    }
}
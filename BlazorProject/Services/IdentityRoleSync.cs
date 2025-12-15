using Microsoft.AspNetCore.Identity;
using BlazorProject.Data;

namespace BlazorProject.Services
{
    public class IdentityRoleSync
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRoleService _roleService;

        public IdentityRoleSync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IRoleService roleService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleService = roleService;
        }

        public async Task SyncUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return;

            var oracleRoles = await _roleService.GetUserRolesAsync(userId);
            
            foreach (var roleName in oracleRoles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            
            var currentRoles = await _userManager.GetRolesAsync(user);
            
            var rolesToRemove = currentRoles.Except(oracleRoles);
            if (rolesToRemove.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
            }
            
            var rolesToAdd = oracleRoles.Except(currentRoles);
            if (rolesToAdd.Any())
            {
                await _userManager.AddToRolesAsync(user, rolesToAdd);
            }
        }
    }
}
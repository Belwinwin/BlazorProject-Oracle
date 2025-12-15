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
            if (user == null) 
            {
                Console.WriteLine($"User not found: {userId}");
                return;
            }

            var oracleRoles = await _roleService.GetUserRolesAsync(userId);
            Console.WriteLine($"Oracle roles for user {userId}: {string.Join(", ", oracleRoles)}");
            
            foreach (var roleName in oracleRoles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                    Console.WriteLine($"Created role: {roleName}");
                }
            }
            
            var currentRoles = await _userManager.GetRolesAsync(user);
            Console.WriteLine($"Current Identity roles: {string.Join(", ", currentRoles)}");
            
            var rolesToRemove = currentRoles.Except(oracleRoles);
            if (rolesToRemove.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                Console.WriteLine($"Removed roles: {string.Join(", ", rolesToRemove)}");
            }
            
            var rolesToAdd = oracleRoles.Except(currentRoles);
            if (rolesToAdd.Any())
            {
                await _userManager.AddToRolesAsync(user, rolesToAdd);
                Console.WriteLine($"Added roles: {string.Join(", ", rolesToAdd)}");
            }
        }

        public async Task SyncUserRolesByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                await SyncUserRolesAsync(user.Id);
            }
        }
    }
}
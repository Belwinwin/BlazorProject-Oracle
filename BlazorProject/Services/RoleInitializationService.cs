using Microsoft.AspNetCore.Identity;
using BlazorProject.Data;

namespace BlazorProject.Services
{
    public class RoleInitializationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRoleService _roleService;

        public RoleInitializationService(
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager,
            IRoleService roleService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _roleService = roleService;
        }

        public async Task InitializeRolesAsync()
        {
            string[] roles = { "Admin", "Manager", "User" };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public async Task SyncUserRolesAsync(ApplicationUser user)
        {
            var oracleRoles = await _roleService.GetUserRolesAsync(user.Id);
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
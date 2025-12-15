using Microsoft.AspNetCore.Identity;
using BlazorProject.Data;

namespace BlazorProject.Services
{
    public class RoleInitializationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleInitializationService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
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


    }
}
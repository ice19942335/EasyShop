using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.Data
{
    public class EasyShopContextInitializer
    {
        private readonly EasyShopContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EasyShopContextInitializer(EasyShopContext ctx, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            await _context.Database.MigrateAsync();

            await InitializeIdentity();
        }

        private async Task InitializeIdentity()
        {
            if (!await _roleManager.RoleExistsAsync(ApplicationUser.RoleUser))
                await _roleManager.CreateAsync(new IdentityRole(ApplicationUser.RoleUser));

            if (!await _roleManager.RoleExistsAsync(ApplicationUser.RoleAdmin))
                await _roleManager.CreateAsync(new IdentityRole(ApplicationUser.RoleAdmin));

            if (await _userManager.FindByEmailAsync(ApplicationUser.AdminUserName) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = ApplicationUser.AdminUserName,
                    Email = ApplicationUser.AdminUserName
                };

                var creationResult = await _userManager.CreateAsync(admin, ApplicationUser.DefaultAdminPassword);

                if (creationResult.Succeeded)
                    await _userManager.AddToRoleAsync(admin, ApplicationUser.RoleAdmin);
            }
        }
    }
}

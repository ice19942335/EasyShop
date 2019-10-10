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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EasyShopContextInitializer(EasyShopContext ctx, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
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
            if (!await _roleManager.RoleExistsAsync(User.RoleUser))
                await _roleManager.CreateAsync(new IdentityRole(User.RoleUser));

            if (!await _roleManager.RoleExistsAsync(User.RoleAdmin))
                await _roleManager.CreateAsync(new IdentityRole(User.RoleAdmin));

            if (await _userManager.FindByEmailAsync(User.AdminUserName) == null)
            {
                var admin = new User
                {
                    UserName = User.AdminUserName,
                    Email = User.AdminUserName
                };

                var creationResult = await _userManager.CreateAsync(admin, User.DefaultAdminPassword);

                if (creationResult.Succeeded)
                    await _userManager.AddToRoleAsync(admin, User.RoleAdmin);
            }
        }
    }
}

using System;
using System.Net.Mime;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.Identity;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Services.Data.FirstRunIdentityInitialization
{
    public class IdentityInitializer
    {
        private readonly EasyShopContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public IdentityInitializer(EasyShopContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Initialize()
        {
            if (!await _roleManager.RoleExistsAsync(DefaultIdentity.RoleAdmin))
                await _roleManager.CreateAsync(new IdentityRole(DefaultIdentity.RoleAdmin));

            if (!await _roleManager.RoleExistsAsync(DefaultIdentity.RoleUser))
                await _roleManager.CreateAsync(new IdentityRole(DefaultIdentity.RoleUser));

            if (await _userManager.FindByEmailAsync(DefaultIdentity.AdminUserName) is null)
            {
                var admin = new AppUser
                {
                    UserName = DefaultIdentity.AdminUserName,
                    Email = DefaultIdentity.AdminUserName,
                    FirstName = DefaultIdentity.DefaultAdminFirstName,
                    LastName = DefaultIdentity.DefaultAdminLastname,
                    EmailConfirmed = true,
                    TransactionPercent = 1,
                    ShopsAllowed = 10
                };

                var creationResult = await _userManager.CreateAsync(admin, DefaultIdentity.DefaultAdminPassword);

                if (!creationResult.Succeeded)
                    throw new ApplicationException("Admin creation failed!");

                await _userManager.AddToRoleAsync(admin, DefaultIdentity.RoleAdmin);
                await _userManager.AddToRoleAsync(admin, DefaultIdentity.RoleUser);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

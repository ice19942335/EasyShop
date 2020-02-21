using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.GameType;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace EasyShop.Services.Data.FirstRunInitialization.IdentityInitialization
{
    public class IdentityInitializer
    {
        private readonly EasyShopContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly int _percentPerTransaction;

        public IdentityInitializer(
            EasyShopContext dbContext, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<AppUser> userManager, 
            IConfiguration configuration,
            PayPalSettings payPalSettings)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
            _configuration = configuration;

            _percentPerTransaction = configuration.GetValue<int>("ServicePercentPerTransaction") + payPalSettings.Fees;
        }

        public async Task InitializeIdentity()
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
                    TransactionPercent = _percentPerTransaction,
                    ShopsAllowed = 10,
                    ProfileImage = DefaultIdentity.DefaultAdminPicture,
                    BirthDate = new DateTime(1994, 10, 05)
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

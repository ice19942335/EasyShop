using System;
using System.Linq;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EasyShopContextInitializer(EasyShopContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Initialize()
        {
            await _context.Database.MigrateAsync();

            await InitializeIdentity();
        }

        private async Task InitializeIdentity()
        {
            if (!await _roleManager.RoleExistsAsync(AppUser.RoleUser))
                await _roleManager.CreateAsync(new IdentityRole(AppUser.RoleUser));

            if (!await _roleManager.RoleExistsAsync(AppUser.RoleAdministrator))
                await _roleManager.CreateAsync(new IdentityRole(AppUser.RoleAdministrator));

            if (await _userManager.FindByNameAsync(AppUser.AdminUserName) == null)
            {
                var admin = new AppUser
                {
                    UserName = AppUser.AdminUserName,
                    Email = AppUser.AdminUserName,
                    FirstName = "Aleksejs",
                    LastName = "Birula",
                    BirthDate = new DateTime(1994, 10, 5),
                    Gender = 1,
                    TransactionPercent = 1,
                    RegistrationDate = DateTime.Now,
                    ShopsAllowed = 10,
                    EmailConfirmed = true,
                    ProfileImage = "default-profile-male.jpg"
                };

                var creationResult = await _userManager.CreateAsync(admin, AppUser.DefaultAdminPassword);

                if (creationResult.Succeeded)
                    await _userManager.AddToRoleAsync(admin, AppUser.RoleAdministrator);
                else
                    throw new ApplicationException("Admin creation error\n" + $"Error list:\n" + $"{string.Join(", ", creationResult.Errors.Select(e => e.Description))}");
                
            }
        }
    }
}

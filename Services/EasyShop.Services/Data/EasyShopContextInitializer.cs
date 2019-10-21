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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public EasyShopContextInitializer(EasyShopContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
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
            if (!await _roleManager.RoleExistsAsync(ApplicationUser.RoleUser))
                await _roleManager.CreateAsync(new IdentityRole(ApplicationUser.RoleUser));

            if (!await _roleManager.RoleExistsAsync(ApplicationUser.RoleAdministrator))
                await _roleManager.CreateAsync(new IdentityRole(ApplicationUser.RoleAdministrator));

            if (await _userManager.FindByNameAsync(ApplicationUser.AdminUserName) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = ApplicationUser.AdminUserName,
                    Email = ApplicationUser.AdminUserName,
                    FirstName = "Aleksejs",
                    LastName = "Birula",
                    BirthDate = new DateTime(1994, 10, 5),
                    Gender = 1,
                    TransactionPercent = 1,
                    RegistrationDate = DateTime.Now,
                    ShopsAllowed = 10,
                    EmailConfirmed = true
                };

                var creationResult = await _userManager.CreateAsync(admin, ApplicationUser.DefaultAdminPassword);

                if (creationResult.Succeeded)
                    await _userManager.AddToRoleAsync(admin, ApplicationUser.RoleAdministrator);
                else
                    throw new ApplicationException("Admin creation error\n" + $"Error list:\n" + $"{string.Join(", ", creationResult.Errors.Select(e => e.Description))}");
                
            }
        }
    }
}

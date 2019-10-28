using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using EasyShop.Domain.Entities.Identity;
using EasyShop.Domain.ViewModels.Account;
using EasyShop.Domain.ViewModels.User.UserProfile;
using EasyShop.Interfaces.CP;
using EasyShop.Services.CP.UserProfile;
using EasyShop.Services.Mappers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserProfileServiceSql _userProfileService;

        public UserProfileController(UserManager<ApplicationUser> userManager, IUserProfileServiceSql userProfileService)
        {
            _userManager = userManager;
            _userProfileService = userProfileService;
        }

        public IActionResult PasswordResetRequest() => View();

        public IActionResult PasswordResetRequestHasBeenSent() => View();

        public IActionResult EmailConfirmation() => View();

        public IActionResult EmailConfirmationRequestHasBeenSent() => View();

        [HttpPost]
        public async Task<IActionResult> ProfileImageUpload([FromBody] UserProfileViewModel model)
        {
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user is null)
                return RedirectToAction("AccessDenied", "Account");

            var model = user.CreateViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profile([FromForm] UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            var result = await _userProfileService.UpdateUserData(model);

            return View(result);
        }

    }
}
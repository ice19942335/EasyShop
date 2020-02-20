using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.Profile;
using EasyShop.Domain.ViewModels.ControlPanel.User.UserProfile;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.FileImage;
using EasyShop.Interfaces.Services.CP.UserProfile;
using EasyShop.Services.ExtensionMethods;
using EasyShop.Services.Mappers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServerMonetization.CP.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserProfileService _userProfileService;
        private readonly ILogger<UserProfileController> _logger;
        private readonly IFileImageService _fileImageService;

        public UserProfileController(
            UserManager<AppUser> userManager,
            IUserProfileService userProfileService,
            IFileImageService fileImageService,
            ILogger<UserProfileController> logger)
        {
            _userManager = userManager;
            _userProfileService = userProfileService;
            _fileImageService = fileImageService;
            _logger = logger;
        }

        public async Task<IActionResult> Profile(UpdateUserProfileEnum status = UpdateUserProfileEnum.Default)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user is null)
                return RedirectToAction("AccessDenied", "Account");

            var model = user.CreateViewModel();

            if (status == UpdateUserProfileEnum.Updated)
                model.Status = UpdateUserProfileEnum.Updated;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profile([FromForm] UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage)).ToList();
                errors.ForEach(x => ModelState.AddModelError("", x));
                return View(model);
            }

            var result = await _userProfileService.UpdateUserData(model);

            if (result == UpdateUserProfileEnum.ImageSizeIsTooBig)
            {
                ModelState.AddModelError("", "Image max size 10Mb");
                model.Status = UpdateUserProfileEnum.ImageSizeIsTooBig;
                return View(model);
            }


            if (result == UpdateUserProfileEnum.UserNotFound)
                return RedirectToAction("AccessDenied", "Account");


            if (result == UpdateUserProfileEnum.Updated)
                return RedirectToAction("Profile", new { status = UpdateUserProfileEnum.Updated });


            return RedirectToAction("NotFoundPage", "Home");
        }

        public IActionResult PasswordResetRequest() => View();

        public IActionResult PasswordResetRequestHasBeenSent() => View();

        public IActionResult EmailConfirmation() => View();

        public IActionResult EmailConfirmationRequestHasBeenSent() => View();

        public IActionResult EmailHaveToBeConfirmed() => View();

        public IActionResult SomethingWentWrong() => View();

    }
}
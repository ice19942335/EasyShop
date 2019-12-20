using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.User.UserProfile;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Services.Mappers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserProfileServiceSql _userProfileService;
        private readonly IFileImageService _fileImageService;

        public UserProfileController(
            UserManager<AppUser> userManager, 
            IUserProfileServiceSql userProfileService,
            IFileImageService fileImageService)
        {
            _userManager = userManager;
            _userProfileService = userProfileService;
            _fileImageService = fileImageService;
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

            if (model.ImageToUpload != null)
            {
                var saveFileResult = await _fileImageService.SaveFile(model, "UserImages");
                model.ProfileImage = saveFileResult;

                if(saveFileResult is null)
                {
                    ModelState.AddModelError("", "Can't save selected picture, max size 10MB, picture type should be .jpeg .jpg or .png ");
                    return View(model);
                }
            }

            var result = await _userProfileService.UpdateUserData(model);

            return View(result);
        }

        public IActionResult PasswordResetRequest() => View();

        public IActionResult PasswordResetRequestHasBeenSent() => View();

        public IActionResult EmailConfirmation() => View();

        public IActionResult EmailConfirmationRequestHasBeenSent() => View();

        public IActionResult EmailHaveToBeConfirmed() => View();

        public IActionResult SomethingWentWrong() => View();

    }
}
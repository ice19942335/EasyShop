using System.Threading;
using System.Threading.Tasks;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.ViewModels.User.UserData;
using EasyShop.Domain.ViewModels.User.UserProfile;
using EasyShop.Interfaces.Services.CP;
using EasyShop.Interfaces.Services.CP.FileImage;
using EasyShop.Interfaces.Services.CP.UserProfile;
using EasyShop.Services.ExtensionMethods;
using EasyShop.Services.Mappers.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyShop.CP.UI.Controllers
{
    [Authorize(Roles = "Admin,User")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserProfileService _userProfileService;
        private readonly IFileImageService _fileImageService;
        private readonly ILogger<UserProfileController> _logger;

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

                var userForLog = await _userManager.FindByEmailAsync(HttpContext.User.Identity.Name);
                _logger.LogInformation("UserName: {0} | UserId: {1} | Request: {2} | Message: {3}",
                    userForLog.UserName,
                    userForLog.Id,
                    HttpContext.Request.GetRawTarget(),
                    $"New picture was successfully saved. Picture name: {saveFileResult}");
            }

            var result = await _userProfileService.UpdateUserData(model);

            return View(result);
        }

        public async Task<IActionResult> Main()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);

            if (user is null)
                return RedirectToAction("SomethingWentWrong", "UserProfile");

            var model = new AppUserViewModel
            {
                TransactionPercent = user.TransactionPercent,
                ShopsAllowed = user.ShopsAllowed,
                TotalRevenue = user.TotalRevenue
            };

            return View(model);
        }

        public IActionResult PasswordResetRequest() => View();

        public IActionResult PasswordResetRequestHasBeenSent() => View();

        public IActionResult EmailConfirmation() => View();

        public IActionResult EmailConfirmationRequestHasBeenSent() => View();

        public IActionResult EmailHaveToBeConfirmed() => View();

        public IActionResult SomethingWentWrong() => View();

    }
}
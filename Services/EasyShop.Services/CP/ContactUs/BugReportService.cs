using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.Entries.ContactUs.BugReports;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Enums.CP.ContactUs;
using EasyShop.Domain.Enums.CP.ContactUs.BugReports;
using EasyShop.Domain.ViewModels.CP.ContactUs;
using EasyShop.Interfaces.Email;
using EasyShop.Interfaces.Services.CP.ContactUs;
using EasyShop.Interfaces.Services.CP.FileImage;
using EasyShop.Services.ExtensionMethods;
using EasyShop.Services.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyShop.Services.CP.ContactUs
{
    public class BugReportService : IBugReportService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly EasyShopContext _context;
        private readonly IFileImageService _fileImageService;
        private readonly ISmtpEmailSender _smtpEmailSender;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<BugReportService> _logger;

        public BugReportService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager,
            EasyShopContext context,
            IFileImageService fileImageService,
            ISmtpEmailSender smtpEmailSender,
            IWebHostEnvironment environment,
            ILogger<BugReportService> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
            _fileImageService = fileImageService;
            _smtpEmailSender = smtpEmailSender;
            _environment = environment;
            _logger = logger;
        }

        public async Task<bool> CreateBugReport(CreateBugReportViewModel model, IUrlHelper url)
        {
            var bugReportCategory = _context.BugReportCategories.First(x => x.Index == (BugReportCategoriesEnum)model.SelectedCategory);
            var reportStatus = _context.ReportStatus.First(x => x.Index == ReportStatusEnum.WaitingForReview);

            string homePage = url.Action("Index", "Home", new {}, protocol: _httpContextAccessor.HttpContext.Request.Scheme);
            var html = await InterpolateDataIntoFile("link", homePage);

            AppUser user = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated
                ? await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name)
                : null;

            var bugReport = new BugReport
            {
                Id = Guid.NewGuid(),
                AppUser = user,
                BugReportCategory = bugReportCategory,
                Status = reportStatus,
                Title = model.Title,
                Email = model.Email,
                Message = model.Message,
                DateTime = DateTime.UtcNow,
                ImgUrl = model.ImageToUpload != null 
                    ? await _fileImageService.SaveFile(model.ImageToUpload, "BugReportImages") 
                    : null
            };

            try
            {
                _context.BugReports.Add(bugReport);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("UserName: {0} | UserId: {1} | Request: {2} | PostMessage: {3}",
                    user != null ? user.LastName : "Null",
                    user != null ? user.LastName : "Null",
                    _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                    $"Error on saving bug report. Report Title: {model.Title}; Report Message: {model.Message}; User Email: {model.Email}; Error: {e.Message}; Inner exception: {e.InnerException?.Message}; Stacktrace:\n{e.StackTrace};");

                return false;
            }

            var sendEmailResult = await SendMailAsync(model.Email, "Bug report confirmation", html);

            if (!sendEmailResult)
                return false;

            return true;
        }

        private async Task<bool> SendMailAsync(string email, string subject, string html)
        {
            var result = await _smtpEmailSender.SendEmailAsync(email, $"Monetization | {subject}", html);
            return result;
        }

        private async Task<string> InterpolateDataIntoFile(string key, string value, string fileType = "txt", string filename = "BugReportConfirmationEmail", string folderNameInRoot = "Interpolation")
        {
            Dictionary<string, string> data = new Dictionary<string, string> { { key, value } };

            var fileInsertDataHelper = new FileInsertDataHelper(
                _environment,
                filename,
                fileType,
                folderNameInRoot,
                data);

            return await fileInsertDataHelper.GetResult();
        }
    }
}

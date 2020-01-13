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
using EasyShop.Interfaces.Services.CP.ContactUs;
using EasyShop.Interfaces.Services.CP.FileImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EasyShop.Services.CP.ContactUs
{
    public class BugReportService : IBugReportService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly EasyShopContext _context;
        private readonly IFileImageService _fileImageService;

        public BugReportService(
            IHttpContextAccessor httpContextAccessor, 
            UserManager<AppUser> userManager, 
            EasyShopContext context,
            IFileImageService fileImageService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
            _fileImageService = fileImageService;
        }

        public async Task<bool> CreateBugReport(CreateBugReportViewModel model)
        {
            var bugReportCategory = _context.BugReportCategories.First(x => x.Index == (BugReportCategoriesEnum)model.SelectedCategory);
            var reportStatus = _context.ReportStatus.First(x => x.Index == ReportStatusEnum.WaitingForReview);

            var bugReport = new BugReport
            {
                Id = Guid.NewGuid(),
                AppUser = 
                    _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated 
                        ? await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext.User.Identity.Name) 
                        : null,
                BugReportCategory = bugReportCategory,
                Status = reportStatus,
                Title = model.Title,
                Email = model.Email,
                Message = model.Message,
                ImgUrl = await _fileImageService.SaveFile(model.ImageToUpload, "BugReportImages")
            };

            _context.BugReports.Add(bugReport);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

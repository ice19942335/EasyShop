using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using EasyShop.Domain.ViewModels.CP.Admin.BugReport;
using EasyShop.Interfaces.Email;
using EasyShop.Interfaces.Services.CP.Admin.BugReport;
using EasyShop.Services.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.CP.Admin.BugReport
{
    public class AdminBugReportsService : IAdminBugReportsService
    {
        private readonly EasyShopContext _context;
        private readonly ISmtpEmailSender _smtpEmailSender;
        private readonly IWebHostEnvironment _environment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminBugReportsService(EasyShopContext context, ISmtpEmailSender smtpEmailSender, IWebHostEnvironment environment, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _smtpEmailSender = smtpEmailSender;
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<Domain.Entries.ContactUs.BugReports.BugReport> GetAllBugReports()
        {
            return _context.BugReports
                .Include(x => x.BugReportCategory)
                .Include(x => x.AppUser)
                .Include(x => x.Status)
                .OrderBy(x => x.DateTime)
                .AsEnumerable();
        }

        public Domain.Entries.ContactUs.BugReports.BugReport GetReportById(Guid bugId)
        {
            return _context.BugReports
                .Include(x => x.BugReportCategory)
                .Include(x => x.AppUser)
                .Include(x => x.Status)
                .FirstOrDefault(x => x.Id == bugId);
        }

        public async Task<bool> UpdateBugReportStatus(BugReportViewModel model, IUrlHelper url)
        {
            var report = _context.BugReports
                .Include(x => x.Status)
                .FirstOrDefault(x => x.Id == Guid.Parse(model.Id));

            var status = _context.ReportStatus.FirstOrDefault(x => x.Index == model.SelectedStatus);

            if (report is null || status is null)
                return false;

            report.Status = status;

            _context.BugReports.Update(report);
            await _context.SaveChangesAsync();

            string homePage = url.Action("Index", "Home", new { }, protocol: _httpContextAccessor.HttpContext.Request.Scheme);

            Dictionary<string, string> data = new Dictionary<string, string>()
            {
                {"link", homePage},
                {"message", string.IsNullOrEmpty(model.TextAreaMessage) ? "" : $"Message: {model.TextAreaMessage}"},
                {"status", status.Description}
            };

            var html = await InterpolateDataIntoFile(data);
            var sendEmailResult = await SendMailAsync(model.UserEmail, "Bug report status updated!", html);

            if (!sendEmailResult)
                return false;

            return true;
        }

        private async Task<bool> SendMailAsync(string email, string subject, string html)
        {
            var result = await _smtpEmailSender.SendEmailAsync(email, $"Monetization | {subject}", html);
            return result;
        }

        private async Task<string> InterpolateDataIntoFile(Dictionary<string, string> data, string fileType = "txt", string filename = "BugReportUpdateStatusNotificationEmail", string folderNameInRoot = "Interpolation")
        {
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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.Admin.BugReport;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.Interfaces.Services.CP.Admin.BugReport
{
    public interface IAdminBugReportsService
    {
        IEnumerable<Domain.Entries.ContactUs.BugReports.BugReport> GetAllBugReports();

        Domain.Entries.ContactUs.BugReports.BugReport GetReportById(Guid bugId);

        Task<bool> UpdateBugReportStatus(BugReportViewModel model, IUrlHelper url);
    }
}

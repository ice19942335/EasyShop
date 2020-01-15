using System;
using System.Collections.Generic;

namespace EasyShop.Interfaces.Services.CP.Admin.BugReport
{
    public interface IAdminBugReportsService
    {
        IEnumerable<Domain.Entries.ContactUs.BugReports.BugReport> GetAllBugReports();

        Domain.Entries.ContactUs.BugReports.BugReport GetReportById(Guid bugId);
    }
}

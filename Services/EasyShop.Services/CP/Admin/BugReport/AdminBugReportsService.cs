using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using EasyShop.DAL.Context;
using EasyShop.Interfaces.Services.CP.Admin.BugReport;
using Microsoft.EntityFrameworkCore;

namespace EasyShop.Services.CP.Admin.BugReport
{
    public class AdminBugReportsService : IAdminBugReportsService
    {
        private readonly EasyShopContext _context;

        public AdminBugReportsService(EasyShopContext context)
        {
            _context = context;
        }

        public IEnumerable<Domain.Entries.ContactUs.BugReports.BugReport> GetAllBugReports()
        {
            return _context.BugReports
                .Include(x => x.BugReportCategory)
                .Include(x => x.AppUser)
                .Include(x => x.Status)
                .AsEnumerable();
        }
    }
}

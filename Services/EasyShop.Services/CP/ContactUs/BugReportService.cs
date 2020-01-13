using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.CP.ContactUs;
using EasyShop.Interfaces.Services.CP.ContactUs;

namespace EasyShop.Services.CP.ContactUs
{
    public class BugReportService : IBugReportService
    {
        public async Task<bool> CreateBugReport(CreateBugReportViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}

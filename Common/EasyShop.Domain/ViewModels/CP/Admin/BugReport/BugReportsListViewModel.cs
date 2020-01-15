using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.CP.Admin.BugReport
{
    public class BugReportsListViewModel
    {
        public IEnumerable<BugReportViewModel> BugReports { get; set; }
    }
}

using System.Collections.Generic;

namespace EasyShop.Domain.ViewModels.ControlPanel.Admin.BugReport
{
    public class BugReportsListViewModel
    {
        public IEnumerable<BugReportViewModel> BugReports { get; set; }
    }
}

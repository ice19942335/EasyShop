using System;
using System.Collections.Generic;
using System.Text;

namespace EasyShop.Domain.ViewModels.CP.Admin.BugReport
{
    public class BugReportViewModel
    {
        public string Id { get; set; }

        public string UserEmail { get; set; }

        public BugReportCategoryViewModel BugReportCategoryViewModel { get; set; }

        public ReportResponseViewModel ReportResponseViewModel { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string ImgUrl { get; set; }

        public DateTime ReportedDateTime { get; set; }
    }

    public class ReportResponseViewModel
    {
        public string Id { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }
    }

    public class BugReportCategoryViewModel
    {
        public string Id { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }
    }
}

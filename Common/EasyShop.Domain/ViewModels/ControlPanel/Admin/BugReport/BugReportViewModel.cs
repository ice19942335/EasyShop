using System;
using EasyShop.Domain.Enums.CP.ContactUs;

namespace EasyShop.Domain.ViewModels.ControlPanel.Admin.BugReport
{
    public class BugReportViewModel
    {
        public string Id { get; set; }

        public string UserEmail { get; set; }

        public BugReportCategoryViewModel Category { get; set; }

        public ReportResponseViewModel Status { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string ImgUrl { get; set; }

        public DateTime DateTime { get; set; }

        public string TextAreaMessage { get; set; }

        public ReportStatusEnum SelectedStatus { get; set; }
        public bool UpdateResult { get; set; }
    }
}

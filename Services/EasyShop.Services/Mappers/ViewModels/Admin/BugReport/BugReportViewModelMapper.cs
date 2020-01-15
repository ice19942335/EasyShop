using System;
using System.Collections.Generic;
using System.Text;
using EasyShop.Domain.Entries.Rust;
using EasyShop.Domain.ViewModels.CP.Admin.BugReport;
using EasyShop.Domain.ViewModels.CP.ControlPanel.Rust.Category;

namespace EasyShop.Services.Mappers.ViewModels.Admin.BugReport
{
    public static class BugReportViewModelMapper
    {
        public static BugReportViewModel CreateBugReportViewModel(this Domain.Entries.ContactUs.BugReports.BugReport bugReport)
        {
            var model = bugReport.CopyToBugReportViewModel();
            return model;
        }

        private static BugReportViewModel CopyToBugReportViewModel(this Domain.Entries.ContactUs.BugReports.BugReport bugReport)
        {
            var model = new BugReportViewModel
            {
                Id = bugReport.Id.ToString(),
                UserEmail = bugReport.Email,
                Category = new BugReportCategoryViewModel
                {
                    Id = bugReport.BugReportCategory.Id.ToString(),
                    Index = bugReport.BugReportCategory.Index,
                    Description = bugReport.BugReportCategory.Description
                },
                Status = new ReportResponseViewModel
                {
                    Id = bugReport.Status.Id.ToString(),
                    Index = bugReport.Status.Index,
                    Description = bugReport.Status.Description
                },
                Title = bugReport.Title,
                Message = bugReport.Message,
                ImgUrl = bugReport.ImgUrl,
                DateTime = bugReport.DateTime
            };

            return model;
        }
    }
}

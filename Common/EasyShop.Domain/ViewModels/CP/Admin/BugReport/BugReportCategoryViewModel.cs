using EasyShop.Domain.Enums.CP.ContactUs.BugReports;

namespace EasyShop.Domain.ViewModels.CP.Admin.BugReport
{
    public class BugReportCategoryViewModel
    {
        public string Id { get; set; }

        public BugReportCategoriesEnum Index { get; set; }

        public string Description { get; set; }
    }
}
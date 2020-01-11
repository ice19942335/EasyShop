using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Enums.CP.ContactUs.BugReports;

namespace EasyShop.Domain.Entries.ContactUs.BugReports
{
    [Table("BugReportCategories")]
    public class BugReportCategory
    {
        public Guid Id { get; set; }

        public BugReportCategoriesEnum Category { get; set; }
    }
}
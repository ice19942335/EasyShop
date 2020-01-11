using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Enums.CP.ContactUs.GeneralSupport;

namespace EasyShop.Domain.Entries.ContactUs.GeneralSupportReports
{
    [Table("GeneralSupportReportCategories")]
    public class GeneralSupportReportCategory
    {
        public Guid Id { get; set; }

        public GeneralSupportReportCategoryEnum Category { get; set; }
    }
}

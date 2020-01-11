using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Enums.CP.ContactUs.BugReports;
using EasyShop.Domain.Enums.CP.ContactUs.GeneralSupport;

namespace EasyShop.Domain.Entries.ContactUs.GeneralSupport
{
    [Table("GeneralSupportReportCategories")]
    public class GeneralSupportReportCategory
    {
        public Guid Id { get; set; }

        public GeneralSupportReportCategoryEnum Category { get; set; }
    }
}

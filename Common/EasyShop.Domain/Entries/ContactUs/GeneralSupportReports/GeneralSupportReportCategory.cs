using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Enums.CP.ContactUs.GeneralSupport;

namespace EasyShop.Domain.Entries.ContactUs.GeneralSupportReports
{
    [Table("GeneralSupportReportCategories")]
    public class GeneralSupportReportCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public GeneralSupportReportCategoryEnum Category { get; set; }
    }
}

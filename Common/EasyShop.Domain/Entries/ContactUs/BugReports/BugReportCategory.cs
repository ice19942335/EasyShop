using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Enums.CP.ContactUs.BugReports;

namespace EasyShop.Domain.Entries.ContactUs.BugReports
{
    [Table("BugReportCategories")]
    public class BugReportCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public BugReportCategoriesEnum Index { get; set; }
    }
}
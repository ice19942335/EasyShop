using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.ContactUs.BugReports
{
    [Table("BugReports")]
    public class BugReport
    {
        [Key]
        public Guid Id { get; set; }

        public AppUser AppUser { get; set; }

        [Required]
        public BugReportCategory BugReportCategory { get; set; }

        [Required]
        public ReportStatus Status { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public string ImgUrl { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}

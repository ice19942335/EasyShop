using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.ContactUs.GeneralSupportReports
{
    [Table("GeneralSupportReports")]
    public class GeneralSupportReport
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public AppUser AppUser { get; set; }

        [Required]
        public GeneralSupportReportCategory Category { get; set; }

        [Required]
        public ReportResponseStatus Status { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public string ImgUrl { get; set; }
    }
}

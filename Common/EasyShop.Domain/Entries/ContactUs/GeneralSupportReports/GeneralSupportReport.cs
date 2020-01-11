using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.ContactUs.GeneralSupportReports
{
    [Table("GeneralSupportReports")]
    public class GeneralSupportReport
    {
        public Guid Id { get; set; }

        public AppUser AppUser { get; set; }

        public GeneralSupportReportCategory Category { get; set; }

        public ReportResponseStatus Status { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public string ImgUrl { get; set; }
    }
}

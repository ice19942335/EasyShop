using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.ContactUs.GeneralSupport;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.ContactUs.BugReports
{
    [Table("GeneralSupportReports")]
    public class GeneralSupportReport
    {
        public Guid Id { get; set; }

        public AppUser AppUser { get; set; }

        public GeneralSupportReportCategory Category { get; set; }

        public ReportResponseStatus Status { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public string ImgUrl { get; set; }
    }
}

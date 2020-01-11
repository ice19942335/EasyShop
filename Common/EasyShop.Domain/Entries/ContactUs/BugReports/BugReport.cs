using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EasyShop.Domain.Entries.Identity;

namespace EasyShop.Domain.Entries.ContactUs.BugReports
{
    [Table("BugReports")]
    public class BugReport
    {
        public Guid Id { get; set; }

        public AppUser AppUser { get; set; }

        public BugReportCategory BugReportCategory { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Enums.CP.ContactUs;
using EasyShop.Domain.Enums.CP.ContactUs.BugReports;

namespace EasyShop.Domain.Entries.ContactUs.BugReports
{
    [Table("ReportResponseStatus")]
    public class ReportResponseStatus
    {
        public Guid Id { get; set; }

        public ReportResponseStatusEnum Status { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace EasyShop.Domain.Entries.ContactUs.CollaborationReports
{
    [Table("CollaborationReports")]
    public class CollaborationReport
    {
        public Guid Id { get; set; }

        public ReportResponseStatus Status { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}

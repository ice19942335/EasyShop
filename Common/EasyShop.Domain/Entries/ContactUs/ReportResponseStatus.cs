using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Enums.CP.ContactUs;

namespace EasyShop.Domain.Entries.ContactUs
{
    [Table("ReportResponseStatus")]
    public class ReportResponseStatus
    {
        public Guid Id { get; set; }

        public ReportResponseStatusEnum Status { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using EasyShop.Domain.Enums.CP.ContactUs;

namespace EasyShop.Domain.Entries.ContactUs
{
    [Table("ReportStatus")]
    public class ReportStatus
    {
        public Guid Id { get; set; }

        public ReportStatusEnum Index { get; set; }

        public string Description { get; set; }
    }
}

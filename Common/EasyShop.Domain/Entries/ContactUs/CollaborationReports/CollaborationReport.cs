using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EasyShop.Domain.Entries.ContactUs.CollaborationReports
{
    [Table("CollaborationReports")]
    public class CollaborationReport
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public ReportStatus Status { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}

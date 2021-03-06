﻿using EasyShop.Domain.Enums.CP.ContactUs;

namespace EasyShop.Domain.ViewModels.ControlPanel.Admin.BugReport
{
    public class ReportResponseViewModel
    {
        public string Id { get; set; }

        public ReportStatusEnum Index { get; set; }

        public string Description { get; set; }
    }
}
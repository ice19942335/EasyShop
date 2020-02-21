using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyShop.Domain.ViewModels.ControlPanel.ContactUs;
using Microsoft.AspNetCore.Mvc;

namespace EasyShop.Interfaces.Services.CP.ContactUs
{
    public interface IBugReportService
    {
        Task<bool> CreateBugReport(CreateBugReportViewModel model, IUrlHelper url);
    }
}

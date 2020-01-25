using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ServerMonetization.CP.Controllers
{
    public class PrivacyPolicyController : Controller
    {
        public IActionResult ServerMonetizationPrivacyPolicy([FromServices] IWebHostEnvironment env)
        {
            var privacyPolicyPath = Path.Combine(env.WebRootPath + "/PrivacyPolicy");
            var filePath = Path.Combine(privacyPolicyPath + "/PrivacyPolicy.pdf");
            return new PhysicalFileResult(filePath, "application/pdf");
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ServerMonetizationImageHosting.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Get([FromServices] IWebHostEnvironment env, string imageName)
        {
            try
            {
                var image = System.IO.File.OpenRead(Path.Combine(env.WebRootPath, $"RustItems/{imageName}"));
                return File(image, "image/png");
            }
            catch
            {
                return NotFound($"Picture {imageName} not found");
            }
        }
    }
}
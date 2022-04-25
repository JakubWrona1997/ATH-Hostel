using ATH_Hostel.Models;
using ATH_Hostel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ATH_Hostel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }        

        
        public ActionResult Index()
        {
            //var viewModels = new HostelViewModel
            //{
            //    Id = 1,
            //    Name = "Bielsko Hostel",
            //    Address = "ul.Willowa 52",
            //    City = "Bielsko-Biała",
            //    Description = "Stunning hostel for a cheap price",
            //    ImagePaths = new List<string>()
            //    {
            //        "img1.jpg", "img2.jpg"
            //    }
            //};
            //return View(viewModels);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using ATH_Hostel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATH_Hostel.Controllers
{
    public class HostelsController : Controller
    {
        // GET: HostelsController
        public ActionResult Index()
        {
            var viewModels = new List<HostelViewModel>()
            {
                new HostelViewModel
                {
                    Id = 1,
                    Name = "Bielsko Hostel",
                    Address = "ul.Willowa 52",
                    City = "Bielsko-Biała",
                    Description = "Stunning hostel for a cheap price",
                    ImagePaths = new List<string>()
                    {
                    "img1.jpg", "img2.jpg"
                    }
                },
                  new HostelViewModel
                    {
                    Id = 3,
                    Name = "Kato Hostel",
                    Address = "ul.Piłsudzkiego 11",
                    City = "Katowice",
                    Description = "Stunning hostel for a cheap price",
                    ImagePaths = new List<string>()
                    {
                    "img7.jpg", "img3.jpg"
                    }
                  }
            };

            return View(viewModels);
        }


        // GET: HostelsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HostelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HostelsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HostelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HostelsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HostelsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

using ATH_Hostel.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ATH_Hostel.Controllers
{
    public class HostelsController : Controller
    {

        public static IList<HostelItemViewModel> viewModels = new List<HostelItemViewModel>
        {
            new HostelItemViewModel(new HostelViewModel
            {
                Id = 1,
                Name = "Bielsko Hostel",
                Address = "ul.Willowa 52",
                City = "Bielsko-Biała",
                Description = "Astonoshing hostel for a cheap price",
                ImagePaths = new List<string>()
                {
                    "img1.jpg", "img2.jpg"
                }
            })
        };


        // GET: HostelsController
        public ActionResult Index()
        {
            return View(viewModels);
        }

        // GET: HostelsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

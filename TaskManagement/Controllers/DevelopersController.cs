using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskManagement.Models;
using TaskManagement.Models.Application;
using TaskManagement.ViewModels.TaskManagement;

namespace TaskManagement.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly ApplicationDbContext context;

        public DevelopersController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("Developers/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var developer = context.Developers.SingleOrDefault(x => x.Id == id);
            if (developer == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map(developer, new DeveloperFormViewModel());
            return View("DeveloperForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Developers/Update")]
        public ActionResult Update(Developer developer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map(developer, new DeveloperFormViewModel());
                return View("DeveloperForm", viewModel);
            }

            var developerInDb = context.Developers.SingleOrDefault(t => t.Id == developer.Id);
            if (developerInDb == null)
            {
                return HttpNotFound();
            }
            Mapper.Map(developer, developerInDb);

            context.SaveChanges();
            return RedirectToAction("Index", "Developers");
        }
    }
}
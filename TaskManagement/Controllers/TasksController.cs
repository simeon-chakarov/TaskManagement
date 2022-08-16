using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TaskManagement.Models;
using TaskManagement.Models.Application;
using TaskManagement.ViewModels.TaskManagement;

namespace TaskManagement.Controllers
{
    public class TasksController : Controller
    {
        private readonly IApplicationDbContext context;

        public TasksController(IApplicationDbContext context)
        {
            this.context = context;
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

        [Route("Tasks/ByDeveloper/{id}")]
        public ActionResult ByDeveloper(int id)
        {
            var developer = context.Developers.Include(d => d.Tasks).SingleOrDefault(x => x.Id == id);
            if(developer == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "Tasks for " + developer.Name;
            return View("ByDeveloper", developer.Tasks);
        }

        [Route("Tasks/New")]
        public ActionResult New()
        {
            var viewModel = new TaskFormViewModel()
            {
                TaskStatuses = context.TaskStatuses.ToList(),
                TaskTypes = context.TaskTypes.ToList()            
            };

            return View("TaskForm", viewModel);
        }

        [Route("Tasks/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var task = context.Tasks
                .Include(t => t.TaskStatus)
                .Include(t => t.TaskType)
                .Include(t => t.Developer)
                .SingleOrDefault(x => x.Id == id);

            if (task == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map(task, new TaskFormViewModel());
            viewModel.TaskStatuses = context.TaskStatuses.ToList();
            viewModel.TaskTypes = context.TaskTypes.ToList();

            return View("TaskForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Tasks/Create")]
        public ActionResult Create(Task task)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = Mapper.Map(task, new TaskFormViewModel());
                viewModel.TaskStatuses = context.TaskStatuses.ToList();
                viewModel.TaskTypes = context.TaskTypes.ToList();

                return View("TaskForm", viewModel);
            }

            if (task.Id == 0)
            {
                task.CreatedDate = DateTime.Now;
                context.Tasks.Add(task);
            }
            else
            {
                var taskInDb = context.Tasks.SingleOrDefault(t => t.Id == task.Id);
                Mapper.Map(task, taskInDb);
            }

            context.SaveChanges();
            return RedirectToAction("Index", "Tasks");
        }
    }
}
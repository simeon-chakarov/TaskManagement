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
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext context;

        public CommentsController()
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
            var viewModel = new TaskCommentsViewModel()
            {
                IsTableVisible = true,
            };

            return View(viewModel);
        }

        [Route("Comments/ByTask/{taskId}")]
        public ActionResult ByTask(int taskId)
        {
            var task = context.Tasks.Include(t => t.Comments).SingleOrDefault(x => x.Id == taskId);

            if (task == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TaskCommentsViewModel()
            {
                TaskName = task.Name,
                TaskId = task.Id,
                IsTableVisible = task.Comments.Count > 0
            };

            return View("Index", viewModel);
        }

        [Route("Comments/New/{taskId}")]
        public ActionResult New(int taskId)
        {
            var viewModel = new CommentFormViewModel()
            {
                IsByTask = true,
                TaskId = taskId,
                CommentTypes = context.CommentTypes.ToList(),
            };

            return View("CommentForm", viewModel);
        }

        [Route("Comments/Edit/{id}/{isByTask}")]
        public ActionResult Edit(int id, bool isByTask)
        {
            var comment = context.Comments.SingleOrDefault(x => x.Id == id);
            if (comment == null)
            {
                return HttpNotFound();
            }

            var viewModel = Mapper.Map(comment, new CommentFormViewModel());
            viewModel.IsByTask = isByTask;
            viewModel.CommentTypes = context.CommentTypes.ToList();

            return View("CommentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Comments/Create")]
        public ActionResult Create(CommentFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CommentTypes = context.CommentTypes.ToList();
                return View("CommentForm", viewModel);
            }

            if (viewModel.Id == 0)
            {
                var comment = Mapper.Map(viewModel, new Comment());
                comment.DateAdded = DateTime.Now;
                context.Comments.Add(comment);
            }
            else
            {
                var commentInDb = context.Comments.SingleOrDefault(c => c.Id == viewModel.Id);
                Mapper.Map(viewModel, commentInDb);
            }

            context.SaveChanges();
            return viewModel.IsByTask ?
                RedirectToAction("ByTask", "Comments", new { taskId = viewModel.TaskId }) :
                RedirectToAction("Index", "Comments");
        }
    }
}
using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TaskManagement.Dtos;
using TaskManagement.Models;
using TaskManagement.Models.Application;

namespace TaskManagement.Controllers.Api
{
    public class TasksController : ApiController
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

        // GET /api/tasks
        public IHttpActionResult GetTasks(string query = null)
        {
            var tasksQuery = !string.IsNullOrEmpty(query) ?
                context.Tasks.Where(t => t.Name.Contains(query)) :
                context.Tasks;

            var tasks = tasksQuery
                .Include(t => t.Comments)
                .Include(t => t.TaskStatus)
                .Include(t => t.TaskType)
                .Include(t => t.Developer)
                .Select(Mapper.Map<Task, TaskDto>)
                .ToList();

            return Ok(tasks);
        }

        // DELETE /api/tasks/1
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            var taskInDb = context.Tasks.SingleOrDefault(t => t.Id == id);
            if (taskInDb == null)
            {
                return NotFound();
            }

            context.Tasks.Remove(taskInDb);
            context.SaveChanges();

            return Ok(taskInDb.Id);
        }
    }
}

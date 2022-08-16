using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using TaskManagement.Dtos;
using TaskManagement.Models;
using TaskManagement.Models.Application;

namespace TaskManagement.Controllers.Api
{
    public class CommentsController : ApiController
    {
        private readonly IApplicationDbContext context;

        public CommentsController(IApplicationDbContext context)
        {
            this.context = context;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            context.Dispose();
        }

        // GET /api/comments
        public IHttpActionResult GetComments(int? id = null)
        {
            var query = id.HasValue ?
                context.Comments.Where(c => c.TaskId == id.Value) :
                context.Comments;

            var result = query
                .Include(c => c.Task)
                .Include(c => c.CommentType)
                .Select(Mapper.Map<Comment, CommentDto>)
                .ToList();
            return Ok(result);
        }

        // DELETE /api/comments/1
        [HttpDelete]
        public IHttpActionResult DeleteComment(int id)
        {
            var commentInDb = context.Comments.SingleOrDefault(c => c.Id == id);
            if (commentInDb == null)
            {
                return NotFound();
            }

            context.Comments.Remove(commentInDb);
            context.SaveChanges();

            return Ok(commentInDb.Id);
        }
    }
}

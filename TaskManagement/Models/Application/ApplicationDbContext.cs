using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TaskManagement.Models.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Task> Tasks { get; set; }

        DbSet<Comment> Comments { get; set; }

        DbSet<TaskStatus> TaskStatuses { get; set; }

        DbSet<TaskType> TaskTypes { get; set; }

        DbSet<CommentType> CommentTypes { get; set; }

        DbSet<Developer> Developers { get; set; }

        int SaveChanges();

        void Dispose();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public DbSet<TaskType> TaskTypes { get; set; }

        public DbSet<CommentType> CommentTypes { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public ApplicationDbContext()
            : base("TaskManagementConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
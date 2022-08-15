using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TaskManagement.Models;

namespace TaskManagement.ViewModels.TaskManagement
{
    public class TaskFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Display(Name = "Required by Date")]
        public DateTime? RequiredByDate { get; set; }

        [Display(Name = "Description")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Task Status")]
        public byte TaskStatusId { get; set; }

        [Required]
        [Display(Name = "Task Type")]
        public byte TaskTypeId { get; set; }

        public Developer Developer { get; set; }

        [Display(Name = "Assigned to")]
        public byte? DeveloperId { get; set; }


        [Display(Name = "Comments")]
        public List<Comment> Comments { get; set; } = new List<Comment>();

        public IEnumerable<TaskStatus> TaskStatuses { get; set; }

        public IEnumerable<TaskType> TaskTypes { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "New Task" : "Edit Task";
            }
        }
    }
}
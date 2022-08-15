using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagement.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Required by Date")]
        public DateTime RequiredByDate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public TaskStatus TaskStatus { get; set; }

        [Required]
        [Display(Name = "Task Status")]
        public byte TaskStatusId { get; set; }

        public TaskType TaskType { get; set; }

        [Required]
        [Display(Name = "Task Type")]
        public byte TaskTypeId { get; set; }

        public Developer Developer { get; set; }

        [Display(Name = "Assigned to")]
        public byte? DeveloperId { get; set; }


        public List<Comment> Comments { get; set; }
    }
}
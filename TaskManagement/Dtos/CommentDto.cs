using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TaskManagement.Models;

namespace TaskManagement.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        public string Text { get; set; }

        public CommentType CommentType { get; set; }

        [Required]
        [Display(Name = "Comment Type")]
        public byte CommentTypeId { get; set; }

        [Display(Name = "Reminder Date")]
        public DateTime ReminderDate { get; set; }

        public Task Task { get; set; }

        [Required]
        [Display(Name = "Task")]
        public int TaskId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskManagement.Models;

namespace TaskManagement.ViewModels.TaskManagement
{
    public class CommentFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        public string Text { get; set; }

        [Required]
        [Display(Name = "Comment Type")]
        public byte CommentTypeId { get; set; }

        [Required]
        [Display(Name = "Reminder Date")]
        public DateTime? ReminderDate { get; set; }

        public int TaskId { get; set; }

        public IEnumerable<CommentType> CommentTypes { get; set; }

        public bool IsByTask { get; set; }

        public string Title
        {
            get
            {
                return Id == 0 ? "New Comment" : "Edit Comment";
            }
        }
    }
}
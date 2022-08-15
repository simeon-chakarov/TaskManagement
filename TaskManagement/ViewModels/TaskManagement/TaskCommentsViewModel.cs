using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using TaskManagement.Models;

namespace TaskManagement.ViewModels.TaskManagement
{
    public class TaskCommentsViewModel
    {
        public int? TaskId { get; set; }

        public string TaskName { get; set; }

        public bool IsTableVisible { get; set; }

        public bool IsByTask
        {
            get
            {
                return TaskId != null;
            }
        }

        public string Title
        {
            get
            {
                if (string.IsNullOrEmpty(TaskName))
                {
                    return "Comments";
                }
                return "Comments for " + TaskName;
            }
        }
    }
}
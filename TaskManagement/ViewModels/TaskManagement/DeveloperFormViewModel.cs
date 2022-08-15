using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagement.ViewModels.TaskManagement
{
    public class DeveloperFormViewModel
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Title
        {
            get
            {
                return "Change Developer's name";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskManagement.Models;

namespace TaskManagement.Dtos
{
    public class DeveloperDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public List<Task> Tasks { get; set; }
    }
}
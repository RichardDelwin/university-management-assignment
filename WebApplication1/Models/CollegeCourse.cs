using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CollegeCourse
    {

        [Required]
        [Key]
        public int CollegeId { get; set; }
        public College College{ get; set; }
        public int CourseId { get; set; }
        public Course Course{ get; set; }
    }
}

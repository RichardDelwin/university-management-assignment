using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class College
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int UniversityId { get; set; }
        
        [Required] 
        public string Name { get; set; }
        
        //public List<Course> Courses { get; set; }

        public List<Student> Students { get; set; }

        public List<CollegeCourse> CollegeCourses{ get; set; }

        [JsonIgnore]
        public University University { get; set; }
    }
}
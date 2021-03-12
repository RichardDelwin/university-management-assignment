using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public enum CourseName
    {
        Arts,
        Math,
        Science,
        History
    }
    public class Course
    {
        [Required]
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(32)]
        public CourseName Name { get; set; }

        //[Required]
        public List<StudentCourse> Students{ get; set; }
        
        [JsonIgnore]
        public List<CollegeCourse> OfferingColleges { get; set; }


    }
}

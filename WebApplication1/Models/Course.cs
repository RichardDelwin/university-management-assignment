using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    //public enum CourseName
    //{
    //    Arts,
    //    Math,
    //    Science,
    //    History
    //}
    public class Course
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(32)]
        public string courseName { get; set; }

        //[Required]
        public List<StudentCourseCollege> Students { get; set; }

        [JsonIgnore]
        public List<CollegeCourse> OfferingColleges { get; set; }


    }
}

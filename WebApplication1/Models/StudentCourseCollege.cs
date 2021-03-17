using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StudentCourseCollege
    {
        [Key]
        public int Id { get; set; }

        public int? StudentId { get; set; }

        public List<Student> Students { get; set; }

        public int? CollegeId { get; set; }

        public CollegeCourse Colleges { get; set; }

        public int? CourseId { get; set; }

        public Course Courses { get; set; }

    }
}

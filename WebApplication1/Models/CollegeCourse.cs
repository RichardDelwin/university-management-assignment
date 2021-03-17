using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CollegeCourse
    {

        [Required]
        [Key]
        public int CollegeId { get; set; }
        public College College { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication1.Models
{
    public class College
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int UniversityId { get; set; }

        [JsonIgnore]
        public University University { get; set; }

        [JsonIgnore]
        public List<CollegeCourse> CollegeCourses { get; set; }

    }
}
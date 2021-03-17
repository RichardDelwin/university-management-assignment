namespace WebApplication1.Contracts
{
    public class CollegeAndCourse
    {
        public int collegeId { get; set; }
        public string collegeName { get; set; }
        public int courseId { get; set; }
        public string courseName { get; set; }

        public CollegeAndCourse(int collegeId, string collegeName, int courseId, string courseName)
        {
            this.collegeId = collegeId;
            this.collegeName = collegeName;
            this.courseId = courseId;
            this.courseName = courseName;
        }

    }
}

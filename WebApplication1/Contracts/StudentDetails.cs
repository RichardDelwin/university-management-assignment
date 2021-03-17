namespace WebApplication1.Contracts
{
    public class StudentDetails
    {
        public int studentId { get; set; }
        public string StudentName { get; set; }
        public int? collegeId { get; set; }
        //public string? collegeName { get; set; }
        public int? courseId { get; set; }
        //public string? courseName { get; set; }

        //public StudentDetails(int studentId, string StudentName, int? collegeId, string collegeName, int? courseId, string courseName)
        //{
        //    this.studentId = studentId;
        //    this.StudentName = StudentName;
        //    this.collegeId = collegeId;
        //    this.collegeName = collegeName;
        //    this.courseId = courseId;
        //    this.courseName = courseName;
        //}

    }
}

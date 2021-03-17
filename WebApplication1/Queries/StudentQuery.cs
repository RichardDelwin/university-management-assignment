using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Query
{
    public class StudentQuery
    {

        public List<StudentDetails> GetAllStudents(AppDbContext context)
        {
            var studentDetails = (from s in context.Students

                                        join sc in context.StudentCourseColleges on s.Id equals sc.StudentId into sc
                                        from scoursecollege in sc.DefaultIfEmpty()

                                        select new StudentDetails()
                                        {
                                            studentId = s.Id,
                                            StudentName = s.FullName,
                                            courseId = scoursecollege == null ? null : scoursecollege.CourseId,
                                            collegeId = scoursecollege == null ? null : scoursecollege.CollegeId,
                                        }).ToList();
            return studentDetails;

        }

        internal Student GetStudentById(AppDbContext context, int studentId)
        {
            var student = context.Students.FirstOrDefault(c => c.Id == studentId);
            return student;
        }

        public void DeleteStudent(AppDbContext context, Student student)
        {
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public void UpdateStudentDetails(AppDbContext context, int id, Student student)
        {
            context.Entry(student).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void AddStudent(AppDbContext context, Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public List<College> GetCollegeOfferingCourse(AppDbContext context, int courseId)
        {
            var allCollegesOfferingCourse = context.CollegeCourses.
                Include(c => c.College).
                Where(c => c.CourseId == courseId).
                Select(c => c.College).ToList();

            return allCollegesOfferingCourse;
        }

        public bool StudentExists(AppDbContext context, int StudentId)
        {
            return context.Students.Any(s => s.Id == StudentId);
        }

        public bool IsStudentRegisteredtoCourse(AppDbContext context, int StudentId, int? CourseId = null)
        {
            if (CourseId == null)
            {
                return context.StudentCourseColleges.Any(s => s.Id == StudentId);
            }
            return context.StudentCourseColleges.Any(s => s.CourseId == CourseId && s.StudentId == StudentId);
        }
    }
}

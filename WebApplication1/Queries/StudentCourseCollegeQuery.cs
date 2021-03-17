using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Queries
{
    public class StudentCourseCollegeQuery
    {

        internal void RegisterStudentToCourseAndCollege(AppDbContext context, StudentCourseCollege studentCourseCollege)
        {
            context.StudentCourseColleges.Add(studentCourseCollege);

            context.SaveChanges();
        }

        internal StudentCourseCollege GetStudentCourseCollege(AppDbContext context, int studentId, int courseId, int collegeId)
        {
            return context.StudentCourseColleges.FirstOrDefault(s => s.StudentId == studentId && s.CourseId == courseId && s.CollegeId == collegeId);
        }

        internal void DeregisterStudentfromCourseAndCollege(AppDbContext context, StudentCourseCollege studentCourseCollege)
        {
            context.StudentCourseColleges.Remove(studentCourseCollege);
            context.SaveChanges();
        }

        internal void DeregisterMulitpleStudentfromCourseAndCollege(AppDbContext context, List<StudentCourseCollege> studentCourseCollege)
        {
            context.StudentCourseColleges.RemoveRange(studentCourseCollege);
            context.SaveChanges();
        }


        internal List<StudentCourseCollege> GetAllStudentsFromCourseAndCollege(AppDbContext context, int courseId, int collegeId)
        {
            return context.StudentCourseColleges.Where(s => s.CourseId == courseId && s.CollegeId == collegeId).ToList();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Query
{
    public class CourseQuery
    {

        public List<CourseNameId> GetAllCourses(AppDbContext context)
        {
            var courses = context.Courses.
                Select(c => new CourseNameId() { CourseId = c.Id, CourseName = c.courseName })
                .ToList();

            return courses;
        }

        internal Course GetCourseById(AppDbContext context, int courseId)
        {
            var courses = context.Courses.FirstOrDefault(c => c.Id == courseId);
            return courses;
        }

        internal void RegisterCourseIdToCollegeId(AppDbContext context, CollegeCourse collegeCourse)
        {
            context.CollegeCourses.Add(collegeCourse);

            context.SaveChanges();
        }

        public bool courseExistsOnId(AppDbContext context, int CourseId)
        {
            return context.Courses.Any(c => c.Id == CourseId);
        }

        public bool courseExistsOnName(AppDbContext context, string courseName)
        {
            return context.Courses.Any(c => c.courseName == courseName);
        }

        public bool IsCourseRegisteredToCollege(AppDbContext context, int courseId, int collegeId)
        {
            return context.CollegeCourses.Any(c => c.CourseId == courseId && c.CollegeId == collegeId);
        }

        internal void AddNewCourseByNameId(AppDbContext context, Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        internal void DeleteCourseOnId(AppDbContext context, Course course)
        {
            context.Courses.Remove(course);
            context.SaveChanges();
        }

        internal void DeregisterCourseWithCollege(AppDbContext context, CollegeCourse collegeCourse)
        {
            context.CollegeCourses.Remove(collegeCourse);
            context.SaveChanges();
        }
    }
}

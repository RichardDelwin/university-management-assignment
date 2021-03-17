using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Queries
{
    public class CollegesQuery
    {

        public void Add(AppDbContext context, College college)
        {
            context.Colleges.Add(college);
            context.SaveChanges();
        }

        public List<CollegeAndCourse> GetAllCollegesWithCourses(AppDbContext context)
        {
            var collegesAndCourses = (
                                      from college in context.Colleges

                                      join collegecourse in context.CollegeCourses on college.Id equals collegecourse.CollegeId
                                      join course in context.Courses on collegecourse.CourseId equals course.Id

                                      where college.CollegeCourses != null
                                      select new CollegeAndCourse(college.Id, college.Name, course.Id, course.courseName)
                                     ).ToList();

            return collegesAndCourses;
        }

        internal List<CollegeNameId> GetAllCollegesNameId(AppDbContext context)
        {
            var collegeNamesId = context.Colleges.Select(c => new CollegeNameId(c.Id, c.Name)).ToList();
            return collegeNamesId;
        }

        internal College GetCollegeById(AppDbContext context, int collegeId)
        {
            var college = context.Colleges.FirstOrDefault(c => c.Id == collegeId);
            return college;
        }

        internal void DeleteCollege(AppDbContext context, College college)
        {
            context.Colleges.Remove(college);
            context.SaveChanges();
        }

        public bool collegeExistsOnId(AppDbContext context, int CollegeId)
        {
            return context.Colleges.Any(c => c.Id == CollegeId);
        }
    }
}

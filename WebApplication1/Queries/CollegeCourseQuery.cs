using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Queries
{
    public class CollegeCourseQuery
    {
        internal bool ExistsCollegeWithCourse(AppDbContext context, int collegeId, int courseId)
        {
            return context.CollegeCourses.Any(c => c.CollegeId == collegeId && c.CourseId == courseId);
        }
    }
}

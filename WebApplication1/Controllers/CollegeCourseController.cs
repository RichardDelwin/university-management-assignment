using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("/College/RegisterCourseWithCollege")]
    [ApiController]
    public class CollegeCourseController : ControllerBase
    {
        private AppDbContext _context;
        public CollegeCourseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int CollegeId, int CourseId)
        {
            {
                var courseId = await _context.Courses.FindAsync(CourseId);
                var collegeId = await _context.Colleges.FindAsync(CollegeId);
                var collegeCourse = _context.CollegeCourses
                    .Any(c => c.CollegeId == CollegeId && c.CourseId == CourseId);

                if (courseId == null || collegeId == null)
                {
                    return BadRequest();
                }
                else if (collegeCourse)
                {
                    return Ok("Course is already registered");
                }
                else
                {
                    try
                    {
                        _context.CollegeCourses.Add(new CollegeCourse() { CollegeId = CollegeId, CourseId = CourseId });
                        await _context.SaveChangesAsync();
                        return Ok();
                    }
                    catch(Exception e)
                    {
                        return BadRequest(e);
                    }
                }
            }
        }
    }
}

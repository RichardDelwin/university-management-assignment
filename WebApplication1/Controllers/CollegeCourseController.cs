using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("CollegeCourse")]
    [ApiController]
    public class CollegeCourseController : ControllerBase
    {
        private AppDbContext _context;
        CourseService courseService;

        public CollegeCourseController(AppDbContext context)
        {
            _context = context;
            courseService = new CourseService(context);
        }

        [HttpPost("RegisterCourseWithCollege")]
        public IActionResult RegisterCourseWithCollege(CollegeAndCourseId collegeAndCourse)
        {
            try
            {
                var res = courseService.RegisterCourseWithCollege(collegeAndCourse);
                if (res.status)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(res.message);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("DeregisterCourseWithCollege")]
        public IActionResult DeregisterCourseWithCollege(CollegeAndCourseId collegeAndCourse)
        {
            try
            {
                var res = courseService.DeregisterCourseWithCollege(collegeAndCourse);
                if (res.status)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(res.message);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}

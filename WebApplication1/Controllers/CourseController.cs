using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private CourseService courseService;
        private AppDbContext _context { get; set; }

        public CourseController(AppDbContext context)
        {
            _context = context;
            courseService = new CourseService(_context);
        }

        [HttpGet("GetAllCourses")]
        public ActionResult<List<CourseNameId>> GetAllCourses()
        {
            try
            {
                var courses = courseService.GetAllCourses();
                return courses;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpPost("AddNewCourse")]
        public ActionResult AddNewCourse(CourseName course)
        {
            try
            {
                var msg = courseService.AddNewCourse(course);
                if (msg.status)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(msg.message);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete("DeleteCourse")]
        public ActionResult DeleteCourse(int courseId)
        {
            try
            {
                var msg = courseService.DeleteCourseOnId(courseId);
                if (msg.status)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(msg.message);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}



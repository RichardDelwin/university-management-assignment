using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollegeController : ControllerBase
    {
        private AppDbContext _context { get; set; }
        public CollegeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("CollegeNamesAndId")]
        public IEnumerable<Object> GetCollegeNames()
        {
            var colleges = (from c in _context.Colleges
                              select new { c.Name, c.Id}).ToList();
            if (colleges == null)
            {
                return null;
            }
            else
            {
                return colleges;
            }
        }

        //[HttpGet]
        //public IEnumerable<College> Get()
        //{
        //    var colleges = (from c in _context.Colleges
        //                    select c).ToList();

        //    if (colleges == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return colleges;
        //    }
        //}

        [HttpGet]
        [Route("GetCollegeandCourses")]
        public IEnumerable<Object> GetCollegesandCourses()
        {
            var collegesAndCourses = from college in _context.Colleges
                                     join collegecourse in _context.CollegeCourses on college.Id equals collegecourse.CollegeId
                                     join course in _context.Courses on collegecourse.CourseId equals course.Id
                                     where college.CollegeCourses != null
                                     select new
                                     {
                                         collegeId = college.Id,
                                         collegName = college.Name,
                                         courseId = course.Id,
                                         courseName = course.Name
                                     };

            if (collegesAndCourses == null)
            {
                return null;
            }
            else
            {
                return collegesAndCourses;
            }
        }

        [HttpPost]
        [Route("CreateCollege")]
        public async Task<ActionResult<Student>> CreateCollege(College college)
        {
            _context.Colleges.Add(college);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Created(nameof(GetCollegeNames), college);
        }

    }
}



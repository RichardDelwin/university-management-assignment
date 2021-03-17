using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollegeController : ControllerBase
    {
        private AppDbContext _context;
        private CollegeService collegeService = null;

        public CollegeController(AppDbContext context)
        {
            _context = context;
            collegeService = new CollegeService(_context);
        }

        [HttpGet]
        [Route("GetCollegeNamesAndId")]
        public ActionResult<List<CollegeNameId>> GetCollegeNames()
        {
            try
            {
                var colleges = collegeService.GetAllCollegeNamesId();
                if (colleges == null)
                {
                    return NotFound("No colleges are registered");
                }
                return colleges;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet]
        [Route("GetAllCollegesandCourses")]
        public ActionResult<List<CollegeAndCourse>> GetCollegesandCourses()
        {
            try
            {
                var collegesAndCourses = collegeService.GetAllCollegesWithCourses();

                if (collegesAndCourses == null)
                {
                    return NotFound("No Colleges are registered");
                }

                return collegesAndCourses;  

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost]
        [Route("CreateCollege")]
        public ActionResult<Student> CreateCollege(CollegeInput college)
        {

            try
            {
                collegeService.AddNewCollege(college);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Created(nameof(GetCollegesandCourses), college);
        }

        [HttpDelete]
        public ActionResult DeleteCollege(int CollegeId)
        {
            try
            {
                var msg = collegeService.DeleteCollege(CollegeId);

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



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
    public class UniversityController : ControllerBase
    {
        private AppDbContext _context { get; set; }
        private UniversityService universityService { get; set; }

        public UniversityController(AppDbContext context)
        {
            _context = context;
            universityService = new UniversityService(_context);
        }

        [HttpGet]
        [Route("GetAllUniversities")]
        public ActionResult<List<University>> GetAllUniversities()
        {
            try
            {
                return universityService.GetAllUniversities();

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        
        [HttpPost]
        public ActionResult<Student> CreateUniversity(UniversityInput universityInput)
        {

            try
            {
                universityService.CreateNewUniversity(universityInput);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("DeleteUniversity")]
        public IActionResult DeleteUniversity(int UniversityId)
        {
            try
            {
                var msg = universityService.DeleteUniversity(UniversityId);

                if (msg.status)
                {
                    return Ok();
                }
                return NotFound(msg.message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

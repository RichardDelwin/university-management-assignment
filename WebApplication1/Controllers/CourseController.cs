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
    public class CourseController : ControllerBase
    {
        
        private AppDbContext _context { get; set; }

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public static object CourseNameId(String Name, int Id)
        {
            return new { Name = Name, Id = Id };
        }


        [HttpGet]
        public async Task<ActionResult<List<Object>>> Get()
        {
            var courseNames = await _context.Courses.Select(c => CourseNameId(c.Name.ToString(), c.Id)).ToListAsync();

            if (courseNames == null)
            {
                return NotFound();
            }
            else
            {
                return courseNames;
            }
        }

    }
}



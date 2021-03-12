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
    public class UniversityController : ControllerBase
    {
        private AppDbContext _context { get; set; }
        public UniversityController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Id")]
        public IEnumerable<object> UniversityNamesAndId()
        {
            var universityNames = (from uni in _context.Universities
                                select new { uni.Id, uni.Name }).ToList();
            if (universityNames == null)
            {
                return null;
            }
            else
            {
                return universityNames;
            }
        }

        [HttpGet]
        [Route("Colleges")]
        public async Task<IEnumerable<Object>> Get()
        {
            var universities = await 
                                (from uni in _context.Universities

                                    //join coll in _context.Colleges on uni.Id equals coll.Id into c
                                    //from coll in c.DefaultIfEmpty()

                                select new
                                {
                                    uni.Id,
                                    uni.Name,
                                    colleges = (from coll in _context.Colleges
                                                where coll.UniversityId == uni.Id
                                                select new
                                                {
                                                    CollegeId = coll.Id,
                                                    CollegeName = coll.Name
                                                }).ToList()
                                }).ToListAsync();


            if (universities == null)
            {
                return null;
            }
            else
            {
                return universities;
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateUniversity(University university)
        {
            _context.Universities.Add(university);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }

            return Created(nameof(Get),university);
        }
    }
}

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
    public class StudentController : ControllerBase
    {
        private AppDbContext _context { get; set; }
        private bool StudentExists(int id) => _context.Students.Any(s => s.Id == id);
        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //[Route("Names")]
        //public IEnumerable<string> GetStudentNames()
        //{
        //    var studentNames = (from s in _context.Students
        //                        select s.FullName).ToList();
        //    if (studentNames == null)
        //    {
        //        return null;
        //    }
        //    else
        //    {
        //        return studentNames;
        //    }
        //}

        [HttpGet]
        public IEnumerable<Object> Get()
        {
            var studentDetails = (from s in _context.Students

                                  join sc in _context.StudentCourses on s.Id equals sc.StudentId into scourses
                                  from sc in scourses.DefaultIfEmpty()
                            
                                  join c in _context.Courses on sc.CourseId equals c.Id into courses
                                  from c in courses.DefaultIfEmpty()

                                  join col in _context.Colleges on s.CollegeId equals col.Id into coll
                                  from col in coll.DefaultIfEmpty()

                                  select new
                                  {
                                    s.Id,
                                    s.FullName,
                                    courseName = c.Id == null ? string.Empty : c.Name.ToString(),
                                    collegeName = col.Id == null? string.Empty : col.Name
                                  }
                                  ).ToList();

            if (studentDetails == null)
            {
                return null;
            }
            else
            {
                return studentDetails;
            }
        }

        [HttpGet]
        [Route("RegisterCourse")]
        public async Task<IActionResult> RegisterStudentToCourse(int StudentId, int CourseId)
        {
            var student = await _context.Students.FindAsync(StudentId);
            var course = await _context.Courses.FindAsync(CourseId);

            if(student == null || course == null)
            {
                return BadRequest();
            }

            StudentCourse studentcourse = new StudentCourse
            {
                StudentId = StudentId,
                CourseId = CourseId,
            };

            var college = AllotCollege(studentcourse, _context);
            
            if (college == null)
            {
                return NotFound("Sorry, No college currently offers this course");
            }


            await _context.StudentCourses.AddAsync(studentcourse);

            student.CollegeId = college.CollegeId;
            _context.Entry(student).Property("CollegeId").IsModified = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(student).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }


            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok();
        }


        //[ApiExplorerSettings(IgnoreApi = true)]
        //[NonAction]
        public static CollegeCourse AllotCollege(StudentCourse studentcourse, AppDbContext _context)
        {
            var college = _context.CollegeCourses.FirstOrDefault(c => c.CourseId == studentcourse.CourseId);

            if(college != null)
            {
                return college;
            }
            return null;
        }
    }
}

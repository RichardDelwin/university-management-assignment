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
    public class StudentController : ControllerBase
    {
        private AppDbContext _context { get; set; }
        private StudentService studentService { get; set; }

        public StudentController(AppDbContext context)
        {
            _context = context;
            studentService = new StudentService(_context);
        }

        [HttpGet("GetAllStudentDetails")]
        public ActionResult<List<StudentDetails>> GetAllStudentDetails()
        {
            try
            {
                var studentDetails = studentService.GetAllStudentDetails();
                return studentDetails;
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPatch]
        [Route("RegisterCourse")]
        public ActionResult RegisterStudentToCourse(StudentIdCourseId studentCourse)
        {
            try
            {
                var msg = studentService.RegisterStudentToCourse(studentCourse);
                if (msg.status)
                {
                    return Ok(msg.message);
                }
                return BadRequest(msg.message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("DeregisterCourse")]
        public ActionResult<CollegeAndCourse> DeregisterStudentFromCourse(StudentDetails studentDetails)
        {
            try
            {
                var msg = studentService.DeregisterStudentFromCourse(studentDetails);

                if (msg.status)
                {
                    return Ok();
                }
                else
                {
                    return NotFound(msg.message);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost("AddStudent")]
        public ActionResult<Student> CreateStudent(StudentInputDetails student)
        {
            try
            {
                studentService.AddNewStudent(student);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }

        }

        [HttpPut("UpdateStudent")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            try
            {
                var msg = studentService.UpdateStudentDetails(id, student);
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
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("DeleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            var msg = studentService.DeleteStudent(id);

            if (msg.status)
            {
                return Ok();
            }
            return NotFound(msg.message);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Queries;
using WebApplication1.Query;

namespace WebApplication1.Services
{
    public class StudentService
    {

        private AppDbContext context;
        StudentQuery query = null;

        public StudentService(AppDbContext context)
        {
            this.context = context;
            query = new StudentQuery();
        }

        public List<StudentDetails> GetAllStudentDetails()
        {
            return query.GetAllStudents(context);
        }

        public Message RegisterStudentToCourse(StudentIdCourseId studentIdCourseId)
        {
            Message msg = new Message();

            CourseQuery courseQuery = new CourseQuery();
            StudentCourseCollegeQuery studentCourseCollegeQuery = new StudentCourseCollegeQuery();
            StudentQuery studentQuery = new StudentQuery();

            
            if (query.IsStudentRegisteredtoCourse(context, studentIdCourseId.StudentId, studentIdCourseId.CourseId))
            {
                msg.status = false;
                msg.message = "Student is already registered to the course";
            }
            else if(!query.StudentExists(context, studentIdCourseId.StudentId) ||
               !courseQuery.courseExistsOnId(context, studentIdCourseId.CourseId))
            {
                msg.status = false;
                msg.message = "The Student/Course is not registered";
            }


            var college = AllotCollege(studentIdCourseId);
            
            if (college == null)
            {
                msg.status = false;
                msg.message = "No colleges currently offer this course";
            }

            StudentCourseCollege studentCourseCollege = new StudentCourseCollege()
            {
                CollegeId = college.Id,
                StudentId = studentIdCourseId.StudentId,
                CourseId = studentIdCourseId.CourseId,
            };

            try
            {
                studentCourseCollegeQuery.RegisterStudentToCourseAndCollege(context, studentCourseCollege);
                var course = courseQuery.GetCourseById(context, studentIdCourseId.CourseId);
                msg.status = true;
                msg.message = $"Alloted College: {college.Name} (Id : {college.Id})\n for Course : {course.courseName} (id : {course.Id})";
            }
            catch(Exception e)
            {
                msg.status = false;
                msg.message = $"Internal Error : {e.Message}";
            }

            return msg;
        }

        internal Message DeregisterStudentFromCourse(StudentDetails studentDetails)
        {
            Message msg = new Message();
            StudentCourseCollegeQuery studentCourseCollegeQuery = new StudentCourseCollegeQuery();
            
            try
            {
                int studentId = studentDetails.studentId;
                int courseId = (int)studentDetails.courseId;
                int collegeId = (int)studentDetails.collegeId;

                if (query.IsStudentRegisteredtoCourse(context, studentId, courseId))
                {
                    var studentCourseRecord = studentCourseCollegeQuery.GetStudentCourseCollege(context, 
                        studentId, 
                        courseId, 
                        collegeId);

                    if (studentCourseRecord == null)
                    {
                        msg.status = false;
                        msg.message = "Student record for the course doesn't exist";
                    }
                    else
                    {
                        studentCourseCollegeQuery.DeregisterStudentfromCourseAndCollege(context,
                           studentCourseRecord);
                        msg.status = true;
                    }

                }
                else
                {
                    msg.status = false;
                    msg.message = $"The student with {studentId} is not registered to any course";
                }
            }
            catch (Exception e)
            {
                msg.status = false;
                msg.message = e.Message;
            }
            return msg;
        }

        public College AllotCollege(StudentIdCourseId studentcourse)
        {
            Random r = new Random();
            var allColleges = query.GetCollegeOfferingCourse(context, studentcourse.CourseId);
            var college = allColleges[r.Next(0, allColleges.Count)];
            return college;

        }

        public Message AddNewStudent(StudentInputDetails studentinput)
        {
            Message msg = new Message();
            Student student = new Student() { FirstName = studentinput.FirstName, LastName = studentinput.LastName };
            try
            {
                query.AddStudent(context, student);
                msg.status = true;
            }
            catch(Exception e)
            {
                msg.status = false;
                msg.message = $"Internal Error : {e.Message}";
            }
            return msg;
        }

        internal Message UpdateStudentDetails(int id, Student student)
        {
            Message msg = new Message();

            if (id != student.Id)
            {
                msg.status = false;
                msg.message = "The id parameter";
            }

            try
            {
                if (query.StudentExists(context, id))
                {
                    query.UpdateStudentDetails(context, id, student);
                    msg.status = true;
                }
                else
                {
                    msg.status = false;
                    msg.message = "No Student record exist";
                }
            }
            catch(Exception e)
            {
                msg.status = false;
                msg.message = $"Internal Error : {e.Message}";
            }

            return msg;
        }

        public Message DeleteStudent(int id)
        {
            Message msg = new Message();

            try
            {
                if (query.StudentExists(context, id))
                {
                    var student = query.GetStudentById(context, id);
                    query.DeleteStudent(context, student);
                    msg.status = true;
                }
                else
                {

                    msg.status = false;
                    msg.message = "No Student record exist";
                }
            }
            catch(Exception e)
            {
                msg.status = false;
                msg.message = $"Internal Error : {e.Message}";
            }

            return msg;

        }

    }
}

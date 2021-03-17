using System;
using System.Collections.Generic;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Queries;
using WebApplication1.Query;

namespace WebApplication1.Services
{
    public class CourseService
    {
        AppDbContext context;
        CourseQuery query;

        public CourseService(AppDbContext _context)
        {
            context = _context;
            query = new CourseQuery();
        }

        public List<CourseNameId> GetAllCourses()
        {
            return query.GetAllCourses(context);
        }

        internal Message RegisterCourseWithCollege(CollegeAndCourseId collegeAndCourseId)
        {
            CollegesQuery collegeQuery = new CollegesQuery();
            CollegeCourseQuery collegeCourseQuery = new CollegeCourseQuery();
            Message message = new Message();
            
            if (collegeCourseQuery.ExistsCollegeWithCourse(context, collegeAndCourseId.CollegeId, collegeAndCourseId.CourseId))
            {
                message.status = false;
                message.message = "Course Already Registered";
            }
            else if (collegeQuery.collegeExistsOnId(context, collegeAndCourseId.CollegeId)
                        && query.courseExistsOnId(context, collegeAndCourseId.CourseId))
            {
                query.RegisterCourseIdToCollegeId(context, new CollegeCourse()
                {
                    CollegeId = collegeAndCourseId.CollegeId,
                    CourseId = collegeAndCourseId.CourseId
                });
                message.status = true;
            }
            else
            {
                message.status = false;
                message.message = "Invlaid Course/College";
            }

            return message;

        }

        internal Message AddNewCourse(CourseName courseName)
        {
            Message msg = new Message();
            Course course = new Course()
            {
                courseName = courseName.courseName
            };

            try
            {
                if (query.courseExistsOnName(context, courseName.courseName))
                {
                    msg.status = false;
                    msg.message = "Course already exists";
                }
                else
                {
                    query.AddNewCourseByNameId(context, course);
                    msg.status = true;
                }
            }
            catch (Exception e)
            {
                msg.status = false;
                msg.message = $"Internal error: {e}";
            }

            return msg;
        }

        internal Message DeregisterCourseWithCollege(CollegeAndCourseId collegeAndCourseId)
        {
            Message message = new Message();
            StudentCourseCollegeQuery sccQuery = new StudentCourseCollegeQuery();

            if (query.IsCourseRegisteredToCollege(context, collegeAndCourseId.CourseId, collegeAndCourseId.CollegeId))
            {
                try
                {
                    var students = sccQuery.GetAllStudentsFromCourseAndCollege(context, collegeAndCourseId.CourseId, collegeAndCourseId.CollegeId);

                    sccQuery.DeregisterMulitpleStudentfromCourseAndCollege(context, students);

                    query.DeregisterCourseWithCollege(context, new CollegeCourse()
                    {
                        CollegeId = collegeAndCourseId.CollegeId,
                        CourseId = collegeAndCourseId.CourseId
                    });

                    message.status = true;
                }
                catch (Exception e)
                {
                    message.status = false;
                    message.message = e.Message;
                }

            }
            else
            {
                message.status = false;
                message.message = $"The course (id : {collegeAndCourseId.CourseId}), is not registered " +
                    $"with college (id:{collegeAndCourseId.CollegeId})";
            }
            return message;
        }

        internal Message DeleteCourseOnId(int courseId)
        {
            Message msg = new Message();
            try
            {
                var course = query.GetCourseById(context, courseId);
                if (course != null)
                {
                    query.DeleteCourseOnId(context, course);
                    msg.status = true;
                }
                else
                {
                    msg.message = $"There is no Course with id = {courseId}";
                    msg.status = false;
                }
            }
            catch (Exception e)
            {
                msg.message = $"Internal Error : {e}";
                msg.status = false;
            }
            return msg;
        }
    }
}

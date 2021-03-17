using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Queries;

namespace WebApplication1.Services
{
    public class CollegeService
    {
        private AppDbContext context;
        CollegesQuery query = null;

        public CollegeService(AppDbContext context)
        {
            this.context = context;
            query = new CollegesQuery();
        }

        public Message AddNewCollege(CollegeInput collegeinput)
        {
            Message msg = new Message();
            College college = new College()
            {
                Name = collegeinput.CollegeName,
                UniversityId = collegeinput.UniversityId,
            };
            try
            {
                query.Add(context, college);
                msg.status = true;
            }
            catch(Exception e)
            {
                msg.status = false;
                msg.message = e.Message;
            }
            return msg;
        }

        public List<CollegeAndCourse> GetAllCollegesWithCourses()
        {
            return query.GetAllCollegesWithCourses(context);
        }

        internal List<CollegeNameId> GetAllCollegeNamesId()
        {
            var collegesNamesId = query.GetAllCollegesNameId(context);
            return collegesNamesId;
        }

        public College GetCollegeById(int courseId)
        {
            return query.GetCollegeById(context, courseId);
        }

        internal Message DeleteCollege(int collegeId)
        {
            Message msg = new Message();
            try
            {
                var college = GetCollegeById(collegeId);

                if (college != null)
                {
                    query.DeleteCollege(context, college);
                    msg.status = true;
                }
                else
                {
                    msg.status = false;
                    msg.message = "College doesn't exist";
                }
            }
            catch (Exception e)
            {
                msg.status = false;
                msg.message = $"Internal Error : {e}";
            }

            return msg;
        }
    }
}

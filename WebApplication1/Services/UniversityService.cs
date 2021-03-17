using System;
using System.Collections.Generic;
using WebApplication1.Contracts;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Query;

namespace WebApplication1.Services
{
    public class UniversityService
    {
        AppDbContext context;
        UniversityQuery query;

        public UniversityService(AppDbContext context)
        {
            this.context = context;
            query = new UniversityQuery();
        }

        public List<University> GetAllUniversities()
        {
            return query.GetAllUniversity(context);
        }

        public void CreateNewUniversity(UniversityInput universityInput)
        {
            University university = new University()
            {
                Name = universityInput.UniversityName
            };

            query.CreateNewUniversity(context, university);
        }

        internal Message DeleteUniversity(int collegeId)
        {
            Message msg = new Message();
            try
            {
                var university = query.GetUniversityById(context, collegeId);

                if (university != null)
                {
                    query.DeleteUniversity(context, university);
                    msg.status = true;
                }
                else
                {
                    msg.status = false;
                    msg.message = "University doesn't exist";
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

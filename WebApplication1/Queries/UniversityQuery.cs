using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Query
{
    public class UniversityQuery
    {
        public List<University> GetAllUniversity(AppDbContext context)
        {

            var university = (from uni in context.Universities

                              select new University
                              {
                                  Id = uni.Id,
                                  Name = uni.Name,
                                  Colleges = (from coll in context.Colleges
                                              where coll.UniversityId == uni.Id
                                              select coll).ToList()
                              }).ToList();

            return university;
        }

        public void CreateNewUniversity(AppDbContext context, University university)
        {
            context.Universities.Add(university);
            context.SaveChanges();
        }

        internal University GetUniversityById(AppDbContext context, int universityId)
        {
            var university = context.Universities.FirstOrDefault(u => u.Id == universityId);
            return university;
        }

        internal void DeleteUniversity(AppDbContext context, University university)
        {
            context.Universities.Remove(university);
            context.SaveChanges();
        }
    }
}

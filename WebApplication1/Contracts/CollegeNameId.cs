namespace WebApplication1.Contracts
{
    public class CollegeNameId
    {
        public int CollegeId { get; set; }
        public string CollegeName { get; set; }

        public CollegeNameId(int collegeId, string collegeName)
        {
            CollegeId = collegeId;
            CollegeName = collegeName;
        }
    }
}

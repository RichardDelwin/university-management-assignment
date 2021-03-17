namespace WebApplication1.Contracts
{
    public class StudentInputDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public StudentInputDetails(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}

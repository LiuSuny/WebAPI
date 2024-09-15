namespace PersonnalApi.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }

        public IEnumerable<Review> reviews_id { get; set; }

    }
}

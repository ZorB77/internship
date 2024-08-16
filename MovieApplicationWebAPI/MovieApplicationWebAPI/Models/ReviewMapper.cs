namespace MovieApplicationWebAPI.Models
{
    public class ReviewMapper
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int MovieID { get; set; }
    }
}

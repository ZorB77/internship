namespace MovieWebAPI.Models.DTOs
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }
        public int MovieId { get; set; }
    }
}

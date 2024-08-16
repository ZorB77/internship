namespace MovieAppRESTAPI.DTOs.ReviewDTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreationDate { get; set; }
        public int MovieId { get; set; }

    }
}

namespace MovieWebAPI.Models.DTOs
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
    }

}

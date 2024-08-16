namespace MoviesApi.ModelsDTO
{
    public class MovieReadDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public decimal Budget { get; set; }

        public List<StudioReadDto> Studios { get; set; }
        public List<ReviewReadDto> Reviews { get; set; }
    }
}

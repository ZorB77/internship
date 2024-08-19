namespace MoviesApi.ModelsDTO
{
    public class StudioReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }

        public List<MovieReadDto> Movies { get; set; } = new List<MovieReadDto>();
    }
}
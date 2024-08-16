namespace MoviesApi.ModelsDTO
{
    public class PersonReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Nationality { get; set; }
        public int Awards { get; set; }

    }
}

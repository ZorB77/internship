namespace MoviesApi.ModelsDTO
{
    public class RoleReadDto
    {
        public RoleReadDto(string name, int personID, int movieID)
        {
            Name = name;
            MovieID = personID;
            PersonID = movieID;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MovieID { get; set; }
        public int PersonID { get; set; }

    }
}

namespace MovieCollection.model
{
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public Movie(string id, string name, int year, int duration, string description)
        {
            Id = id;
            Name = name;
            Year = year;
            Duration = duration;
            Description = description;
        }


        public override string ToString()
        {
            return $"id: {Id}, name: {Name}, year: {Year}, duration: {Duration}, description: {Description}";
        }
    }
}

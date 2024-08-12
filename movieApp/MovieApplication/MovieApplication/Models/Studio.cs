namespace MovieApplication.Models
{
    public class Studio
    {
        public int StudioID { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string Locatiton { get; set; }
        public ICollection<MovieStudio> MovieStudios { get; set; }
    }
}

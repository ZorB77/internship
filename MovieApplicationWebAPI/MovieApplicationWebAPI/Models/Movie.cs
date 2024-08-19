using System.ComponentModel.DataAnnotations;

namespace MovieApplicationWebAPI.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "The name of the movie is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The release date of the movie is required.")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "The description of the movie is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The genre of the movie is required.")]
        public string Genre { get; set; }
    }
}

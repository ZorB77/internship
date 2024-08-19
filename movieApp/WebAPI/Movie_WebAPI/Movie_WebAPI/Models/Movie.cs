using MovieApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Release date is required.")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Genre is required.")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Budget is required.")]
        public decimal Budget {  get; set; }
        [Required(ErrorMessage = "Duration is required.")]
        public int Duration { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MovieStudio> MovieStudios { get; set; }
    }
}

using MovieApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApp.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public decimal Budget {  get; set; }
        public int Duration { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<MovieStudio> MovieStudios { get; set; }
    }
}

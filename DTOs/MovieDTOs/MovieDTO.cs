using MovieWinForms.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieAppRESTAPI.DTOs.MovieDTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public List<StudioSimplified>? Studios { get; set; }
        public decimal? AverageRating { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
    public class StudioSimplified
    {
       public int Id { get; set; }
        public string Name { get; set; }
    }
}

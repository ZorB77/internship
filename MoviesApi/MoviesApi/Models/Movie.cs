using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Description cannot be longer than 300 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Year is required")]
        [Range(1895, 2024, ErrorMessage = "Year must be between 1895 and 2024")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        [StringLength(100, ErrorMessage = "Genre cannot be longer than 100 characters")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 500, ErrorMessage = "Duration must be between 1 and 500 minutes")]
        public int Duration { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a positive value")]
        public decimal Budget {  get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Studio> Studios { get; set; } = new List<Studio>();

        public Movie() { }

        public Movie(string title, string description, int year, string genre, int duration, decimal budget)
        {
            Title = title;
            Description = description;
            Year = year;
            Genre = genre;
            Duration = duration;
            Budget = budget;
            Reviews = new List<Review>();
            Studios = new List<Studio>();

        }

        public override string ToString()
        {
            return $"{Title} ({Year}) - {Genre}";
        }

        public double GetAverageRating()
        {
            if (Reviews.Count == 0 || Reviews == null)
            {
                return 0;
            }

            return Reviews.Average(x => x.Rating);
        
        }
    }
}

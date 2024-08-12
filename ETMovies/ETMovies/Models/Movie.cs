using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }

        public decimal Budged {  get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Studio> Studios { get; set; } = new List<Studio>();

        public Movie() { }

        public Movie(string title, string description, int year, string genre)
        {
            Title = title;
            Description = description;
            Year = year;
            Genre = genre;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    internal class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public List<Review> Review { get; set; } = new List<Review>();

        public Movie() { }

        public Movie(string title, string description, int year, string genre)
        {
            Title = title;
            Description = description;
            Year = year;
            Genre = genre;
            Review = new List<Review>();

        }

        public override string ToString()
        {
            return $"{Title} ({Year}) - {Genre}";
        }

        public double GetAverageRating()
        {
            if (Review.Count == 0 || Review == null)
            {
                return 0;
            }

            return Review.Average(x => x.Rating);
        
        }
    }
}

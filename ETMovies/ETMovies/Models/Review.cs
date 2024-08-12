using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }

        public Review() { }
        public Review(int rating, string comment)
        {
            Rating = rating;
            Comment = comment;
        }
    }
}

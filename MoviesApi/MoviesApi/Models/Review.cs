using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Models
{
    public class Review
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [Range(0, 100, ErrorMessage = "Rating must be between 0 and 100")]
        public int Rating { get; set; }
        [StringLength(500, ErrorMessage = "Comment cannot be longer than 500 characters")]
        public string Comment { get; set; }

        public Review() { }
        public Review(int rating, string comment)
        {
            Rating = rating;
            Comment = comment;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWebAPI.Models
{
    public class ReviewTests
    {
        [Fact]
        public void ShouldCreateReview()
        {
            var movie = new Movie { ID = 1, Name = "Frozen 2", Description = "Sequel to Frozen.", Genre = "Animation", ReleaseDate = new DateTime(2019, 11, 22) };
            var review = new Review { ID = 1, Comment = "Good.", Movie = movie, Rating = 5 };

            Assert.NotNull(review);
            Assert.IsType<Review>(review);
            Assert.Equal("Frozen 2", review.Movie.Name);
            Assert.Equal("Good.", review.Comment);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWebAPI.Models
{
    public class MovieTests
    {
        [Fact]
        public void ShouldCreateMovie()
        {
            var movie = new Movie { ID = 1, Name = "Interstellar", Description = "Space travelling.", Genre = "Romance", ReleaseDate = new DateTime(2014, 8, 18) };

            Assert.NotNull(movie);
            Assert.IsType<Movie>(movie);
            Assert.Equal(1, movie.ID);
            Assert.Equal("Interstellar", movie.Name);
        }
    }
}
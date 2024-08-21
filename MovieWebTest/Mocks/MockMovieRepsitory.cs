using Moq;
using MovieWebAPI.Persistance;
namespace MovieWebAPI.Mocks
{
    internal class MockMovieRepsitory
    {
        public static Mock<IRepository<Movie>> GetMock() 
        {
            var mock = new Mock<IRepository<Movie>>();

            var movies = new List<Movie>()
            {
                new Movie()
                {
                    MovieId = 1,
                    Name = "Foo",
                    Year = 2000,
                    Description = "Bar",
                    Genre = "Action",
                    Duration = 120
                     
                }
            };

            mock.Setup(m => m.GetAllAsync()).ReturnsAsync(() => movies);

            mock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => movies.FirstOrDefault(movie => movie.MovieId == id));

            mock.Setup(m => m.AddAsync(It.IsAny<Movie>()))
                .Callback<Movie>(m => movies.Add(m))
                .Returns(Task.CompletedTask);

            mock.Setup(m => m.UpdateAsync(It.IsAny<Movie>()))
                .Callback<Movie>(movie =>
                {
                    var existingMovie = movies.FirstOrDefault(m => m.MovieId == movie.MovieId);
                    if (existingMovie != null)
                    {
                        movies.Remove(existingMovie);
                        movies.Add(movie);
                    }
                })
                .Returns(Task.CompletedTask);

            mock.Setup(movie => movie.RemoveAsync(It.IsAny<Movie>()))
                .Callback<Movie>(movie => movies.Remove(movie))
                .Returns(Task.CompletedTask);


            return mock;
        }
    }
}

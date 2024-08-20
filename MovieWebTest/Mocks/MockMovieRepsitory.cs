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

            mock.Setup(m => m.GetAllAsync()).Returns(() => movies);
            mock.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .Returns((int id) => movies.FirstOrDefault(movie => movie.MovieId == id));
            mock.Setup(m => m.AddAsync(It.IsAny<Movie>()))
                .Callback(() => { return; });
            mock.Setup(m => m.UpdateAsync(It.IsAny<Movie>()))
               .Callback(() => { return; });
            mock.Setup(m => m.RemoveAsync(It.IsAny<Movie>()))
               .Callback(() => { return; });

            return mock;
        }
    }
}

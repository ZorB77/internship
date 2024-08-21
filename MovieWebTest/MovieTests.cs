using Moq;
using Movies.Services;
using MovieWebAPI.Exceptions;
using MovieWebAPI.Mocks;

namespace MovieWebAPI
{
    public class MovieTests
    {


        [Fact]
        public void DomainMovieTest()
        {
            var movie = new Movie(1, "test", 20, "test description", "Sci-Fi", 200);

            Assert.NotNull(movie);
            Assert.IsType<Movie>(movie);
            Assert.Equal("test", movie.Name);
        }

        [Fact]
        public async Task AddMovieAsyncTest()
        {
            var repositoryMock = MockMovieRepsitory.GetMock();
            var movieService = new MovieService(repositoryMock.Object);

            await movieService.AddMovieAsync(100, "Test", 2000, "Action", "test description", 120);

            repositoryMock.Verify(r => r.AddAsync(It.IsAny<Movie>()), Times.Once);
            await Assert.ThrowsAsync<NotNullEntity>(() => movieService.AddMovieAsync(1, "Test", 2000, "Action", "test description", 120));

        }

        [Fact]
        public async Task GetByIdAsyncTest()
        {
            var repositoryMock = MockMovieRepsitory.GetMock();
            var movieService = new MovieService(repositoryMock.Object);

            var result = await movieService.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.IsType<Movie>(result);
            await Assert.ThrowsAsync<NullEntity>(() => movieService.GetByIdAsync(2000));
        }

        [Fact]
        public async Task GetAllAsyncTest()
        {
            var movies = new List<Movie>
            {
                new Movie(10, "Test1", 2000, "Action", "test description 1", 120),
                new Movie(11, "Test2", 2001, "Drama", "test description 2", 130)
            };

            var repositoryMock = MockMovieRepsitory.GetMock();
            var movieService = new MovieService(repositoryMock.Object);
            movieService.AddMovieAsync(10, "Test1", 2000, "Action", "test description 1", 120);
            movieService.AddMovieAsync(11, "Test2", 2001, "Action", "test description 2", 130);
            var result = await movieService.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(movies[1].Name, result[2].Name);
        }

        [Fact]
        public async Task UpdateMovieAsyncTest()
        {
            var repositoryMock = MockMovieRepsitory.GetMock();
            var movieService = new MovieService(repositoryMock.Object);

            var movie = await movieService.GetByIdAsync(1);
            Assert.Equal("Foo", movie.Name);

            await movieService.UpdateMovieAsync(1, "Test", 2001, "Updated description", "Drama", 130);
            var movieUpdated = await movieService.GetByIdAsync(1);


            repositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Movie>()), Times.Once);
            Assert.Equal("Test", movieUpdated.Name);
            // assert if movie doesn't exist
            Assert.ThrowsAsync<NullEntity>(() => movieService.UpdateMovieAsync(1000, "Test", 2000, "Action", "test description", 120));

        }

        [Fact]
        public async Task DeleteMovieAsyncTest()
        {
            var repositoryMock = MockMovieRepsitory.GetMock();
            var movieService = new MovieService(repositoryMock.Object);

            Assert.Equal(1, movieService.GetAllAsync().Result.Count);
            await movieService.DeleteMovieAsync(1);

            Assert.Equal(0, movieService.GetAllAsync().Result.Count);
        }
    }
}
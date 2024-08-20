using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

public class MovieServiceTests
{
    private MovieService _movieService;
    private MyDBContext _myDBContext;

    public MovieServiceTests()
    {
        var options = new DbContextOptionsBuilder<MyDBContext>()
            .UseInMemoryDatabase(databaseName: "MovieApplicationTestDatabaseMovies")
            .Options;

        _myDBContext = new MyDBContext(options);
        _myDBContext.movies.RemoveRange(_myDBContext.movies);
        _myDBContext.SaveChanges();

        _myDBContext.movies.AddRange(
            new Movie {ID = 1, Name = "Interstellar", Description = "Space travelling.", Genre = "Romance", ReleaseDate = new DateTime(2014, 8, 18) },
            new Movie {ID = 2, Name = "Frozen", Description = "Two sisters.", Genre = "Animation", ReleaseDate = new DateTime(2014, 12, 5) }
        );
        _myDBContext.SaveChanges();

        _movieService = new MovieService(_myDBContext);
    }

    [Fact]
    public async Task ShouldGetAllMovies()
    {
        var movies = await _movieService.GetAllMoviesAsync();

        Assert.NotNull(movies);
        Assert.Equal(2, movies.ToList().Count());
    }

    [Fact]
    public async Task ShouldGetSpecificMovie()
    {
        var movie = await _movieService.GetMovieAsync(99999);
        var movie2 = await _movieService.GetMovieAsync(1);

        Assert.Null(movie);
        Assert.NotNull(movie2);
        Assert.Equal("Interstellar", movie2.Name);

        
    }

    [Fact]
    public async Task ShouldAddMovie()
    {
        var newMovie = new Movie { Name = "Inception", Description = "Good thriller.", Genre = "Sci-Fi", ReleaseDate = new DateTime(2010, 7, 16) };

        await _movieService.AddMovieAsync(newMovie);
        var movie = await _myDBContext.movies.FirstOrDefaultAsync(m => m.Name == "Inception");

        Assert.NotNull(movie);
        Assert.Equal("Sci-Fi", movie.Genre);
    }

    [Fact]
    public async Task ShouldUpdateMovie()
    {
        var movieToUpdate = new Movie {ID = 1, Name = "Frozen 2", Description = "Sequel to Frozen.", Genre = "Animation", ReleaseDate = new DateTime(2019, 11, 22) };

        await _movieService.UpdateMovieAsync(1, movieToUpdate);
        var updatedMovie = await _movieService.GetMovieAsync(1);

        Assert.NotNull(updatedMovie);
        Assert.Equal("Frozen 2", updatedMovie.Name);
        Assert.Equal("Sequel to Frozen.", updatedMovie.Description);
    }

    [Fact]
    public async Task ShouldDeleteMovie()
    {
        await _movieService.DeleteMovieAsync(2);
        var deletedMovie = await _myDBContext.movies.FirstOrDefaultAsync(m => m.ID == 2);

        Assert.Null(deletedMovie);
    }

}

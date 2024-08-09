using Microsoft.Extensions.DependencyInjection;
using MovieApp.Services;

namespace MovieApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Something");
            var serviceProvider = new ServiceCollection()
                .AddSingleton<MovieContext>()
                .AddSingleton<IMovieService, MovieService>()
                .BuildServiceProvider();

            var movieService = serviceProvider.GetService<IMovieService>();

            if (movieService != null)
            {
                var movies = movieService.GetAllMovies();

                if (movies != null && movies.Any())
                {
                    Console.WriteLine("The list of movies: ");
                    foreach (var movie in movies)
                    {
                        Console.WriteLine($"- {movie.Title}");
                    }
                }
                else
                {
                    Console.WriteLine("No movies found.");
                }
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }
    }
}

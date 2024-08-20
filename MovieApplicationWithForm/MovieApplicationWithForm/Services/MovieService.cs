using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApplicationWithForm.Services
{
    public class MovieService
    {
        private HttpClient httpClient;

        public MovieService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<Movie> GetAllMovies()
        {
            var response = httpClient.GetAsync("api/movies").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Movie>>(jsonResponse);
        }

        public List<Movie> GetMovies(string column, string criteria)
        {
            var movies = GetAllMovies();
            if (column == "Name")
            {
                movies = movies.Where(m => m.name.Contains(criteria)).ToList();
            }
            else if (column == "Genre")
            {
                movies = movies.Where(m => m.genre.Contains(criteria)).ToList();
            }
            else if (column == "Release Year")
            {
                movies = movies.Where(m => m.releaseDate.Year == int.Parse(criteria)).ToList();
            }
            return movies.ToList();
        }

        public Movie GetMovie(int movieId)
        {
            //var url = $"api/movies/{movieId}";
            //Debug.WriteLine($"Request url: {url}");
            var response = httpClient.GetAsync($"api/movies/{movieId}").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Movie>(jsonResponse);
        }

        public Movie GetMovieByName(string name)
        {
            var movies = GetAllMovies();
            var movie = movies.SingleOrDefault(m => m.name == name);
            return movie;
        }


        public void AddMovie(Movie movie)
        {
            var movieJson = JsonSerializer.Serialize(movie);
            var content = new StringContent(movieJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("api/movies", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void UpdateMovie(Movie movie)
        {
            var movieJson = JsonSerializer.Serialize(movie);
            var content = new StringContent(movieJson, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync($"api/movies/{movie.id}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeleteMovie(int movieId)
        {
            Debug.WriteLine($"Movie id:{movieId}");
            var response = httpClient.DeleteAsync($"api/movies/{movieId}").Result;
            response.EnsureSuccessStatusCode();
        }

        public List<Review> GetAllReviewsForMovie(string movieName)
        {
            var response = httpClient.GetAsync("api/reviews").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;

            var allReviews = JsonSerializer.Deserialize<List<Review>>(jsonResponse);
            var filteredReviews = allReviews.Where(r => r.movie.name == movieName).ToList();

            return filteredReviews;
        }
        public double AverageRatingForMovie(int movieID)
        {
            var movie = GetMovie(movieID);
            if (movie == null)
            {
                return -1;
            }

            var reviews = GetAllReviewsForMovie(movie.name);
            if (reviews.Any())
            {
                return reviews.Average(r => r.rating);
            }
            else
            {
                return -1;
            }
        }

        public string BestRatedMovies()
        {
            var allMovies = GetAllMovies();
            var moviesWithRatings = new List<(string MovieName, int MovieID, double AverageRating)>();

            foreach (var movie in allMovies)
            {
                double averageRating = AverageRatingForMovie(movie.id);

                if (averageRating != -1)
                {
                    moviesWithRatings.Add((movie.name, movie.id, averageRating));
                }
            }

            var topMovies = moviesWithRatings
                .OrderByDescending(m => m.AverageRating)
                .Take(10)
                .ToList();

            var result = new StringBuilder();
            result.AppendLine("Best rated movies are:");

            if (topMovies.Any())
            {
                foreach (var movie in topMovies)
                {
                    result.AppendLine($"{movie.MovieID}. {movie.MovieName}: {movie.AverageRating:F1}");
                }
            }
            else
            {
                result.AppendLine("There are no reviewed movies in the database.");
            }

            return result.ToString();
        }




    }
}

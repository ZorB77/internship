using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication
{
    public class MovieService
    {
        private MyDBContext db;
        public MovieService(MyDBContext db) { this.db = db; }
        public int addMovie(string name, DateTime releaseDate, string description, string genre)
        {
            db.Add(new Movie { name = name, releaseDate = releaseDate, description = description, genre = genre });
            db.SaveChanges();
            return 0;
        }

        public int deleteMovie(int movieID)
        {
            Movie movie = db.movies.SingleOrDefault(m => m.movieID == movieID);
            if (movie != null)
            {
                db.Remove(movie);
                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public int updateMovie(int movieID, string name, DateTime releaseDate, string description, string genre)
        {
            Movie movie = db.movies.SingleOrDefault(m => m.movieID == movieID);
            if (movie != null)
            {
                movie.name = name;
                movie.releaseDate = releaseDate;
                movie.description = description;
                movie.genre = genre;

                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public string printMovies()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();
            s.AppendLine("The list of movies is:");

            foreach (Movie movie in db.movies)
            {
                s.AppendLine($"{movie.movieID}. {movie.name}, {movie.releaseDate}. {movie.genre} \n{movie.description}\n");
            }
            return s.ToString();
        }

        public string getMovieInformation(int movieID)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();

            Movie movie = db.movies.SingleOrDefault(m => m.movieID == movieID);
            if (movie != null)
            {
                s.AppendLine("Name: " + movie.name);
                s.AppendLine("Year: " + movie.releaseDate);
                s.AppendLine("Description: " + movie.description);
                s.AppendLine("Genre: " + movie.genre);
            }
            else
            {
                s.AppendLine("There is no movie with such id.");
            }
            return s.ToString();
        }

        public string filterMoviesByYear(int year)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();
            s.AppendLine($"The list of movies from the year {year} is:");

            List<Movie> movies = db.movies.Where(m => m.releaseDate.Year == year).ToList();

            if (movies.Any())
            {
                foreach (Movie movie in movies)
                {
                    s.AppendLine($"{movie.movieID}. {movie.name}, {movie.releaseDate.ToString("yyyy-MM-dd")}");
                }
            }
            else
            {
                s.AppendLine("No movies found for the given year.");
            }

            return s.ToString();
        }

        public string filterMoviesByGenre(string genre)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();
            s.AppendLine($"The list of movies having the genre {genre} is:");

            List<Movie> movies = db.movies.Where(m => m.genre == genre).ToList();

            if (movies.Any())
            {
                foreach (Movie movie in movies)
                {
                    s.AppendLine($"{movie.movieID}. {movie.name}");
                }
            }
            else
            {
                s.AppendLine("No movies found for the given genre.");
            }

            return s.ToString();
        }

        public string filterMoviesByTimeInterval(DateTime d1, DateTime d2)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine();
            s.AppendLine("Movies which have the release date between " + d1.ToString("yyyy-MM-dd") + " and " + d2.ToString("yyyy-MM-dd") + ":");
            foreach (Movie movie in db.movies)
            {
                if (movie.releaseDate >=  d1 && movie.releaseDate <= d2)
                {
                    s.AppendLine(movie.name + " - " + movie.releaseDate.ToString("yyyy-MM-dd"));
                }
            }
            if (s.Length == 0)
            {
                s.AppendLine("There are no movies which were released in this time interval.");
            }

            return s.ToString();
        }

        public string sortMoviesBasedOnCriteria(string sortingCriteria)
        {
            List<Movie> allMovies = db.movies.ToList();
            Comparison<Movie> comparison;
            if (sortingCriteria == "name")
            {
                comparison = (m1, m2) => string.Compare(m1.name, m2.name);
            }
            else if (sortingCriteria == "releaseDate")
            {
                comparison = (m1, m2) => DateTime.Compare(m1.releaseDate, m2.releaseDate);
            }
            else
            {
                return "Invalid sorting criteria.";
            }

            allMovies.Sort(comparison);


            if (allMovies.Any())
            {
                var result = new StringBuilder();
                result.AppendLine("Movies sorted by " + sortingCriteria + ":");
                foreach (var movie in allMovies)
                {
                    result.AppendLine($"{movie.name} (Released: {movie.releaseDate}");
                }
                return result.ToString();
            }
            else
            {
                return "There are no movies in the database.";
            }


        }

        public void printMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add a movie.");
            Console.WriteLine("2. Delete a movie.");
            Console.WriteLine("3. Update a movie.");
            Console.WriteLine("4. See all movies.");
            Console.WriteLine("5. See information about a given movie.");
            Console.WriteLine("6. Filter movies by year.");
            Console.WriteLine("7. Filter movies by genre.");
            Console.WriteLine("8. Filter movies by time interval.");
            Console.WriteLine("9. Sort movies based on their name.");
            Console.WriteLine("10.Top 10 best rated movies.");
            Console.WriteLine("0. Back to the main menu.");
        }

    }
}

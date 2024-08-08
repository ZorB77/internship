using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplication
{
    public class MovieService
    {
        private MyDBContext db;
        public MovieService(MyDBContext db) { this.db = db; }
        public int addMovie(string name, int year, string description, string genre)
        {
            db.Add(new Movie { name = name, year = year, description = description, genre = genre });
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

        public int updateMovie(int movieID, string name, int year, string description, string genre)
        {
            Movie movie = db.movies.SingleOrDefault(m => m.movieID == movieID);
            if (movie != null)
            {
                movie.name = name;
                movie.year = year;
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

            foreach (var movie in db.movies)
            {
                s.AppendLine($"{movie.movieID}. {movie.name}");
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
                s.AppendLine("Year: " + movie.year);
                s.AppendLine("Description: " + movie.description);
                s.AppendLine("Genre: " + movie.genre);
            }
            else
            {
                s.AppendLine("There is no movie with such id.");
            }
            return s.ToString();
        }

        public void printMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add a movie.");
            Console.WriteLine("2. Delete a movie.");
            Console.WriteLine("3. Update a movie.");
            Console.WriteLine("4. See all movies.");
            Console.WriteLine("5. See information about a given movie.");
            Console.WriteLine("0. Exit application.");
        }

    }
}

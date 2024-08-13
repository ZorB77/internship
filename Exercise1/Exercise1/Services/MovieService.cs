using Exercise1.Models;
using Exercise1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Unity.Injection;

namespace Exercise1.Services
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IStudioRepository _studioRepository;

        public MovieService(IMovieRepository movieRepository, IStudioRepository studioRepository)
        {
            _movieRepository = movieRepository;
            _studioRepository = studioRepository;
        }
        //add movie
        public void AddNewMovie()
        {
            var movie = new Movie
            {
                Name = Validation("Enter the movie name: "),
                Year = ValidationInt("Enter movie year: ", 1900, 2024),
                Description = Validation("Enter movie descrption: "),
                Genre = Validation("Enter movie genre: "),
                Studios = new List<Studio>()
            };
            var AddNewStudio = true;
            while (AddNewStudio)
            {
                string studioName = Validation("enter the studio name; ");
                if (!string.IsNullOrWhiteSpace(studioName))
                {
                    var studio = _studioRepository.GetStudio(studioName);

                    if (studio != null)
                    {
                        Console.WriteLine($"Studio found {studio.StudioName}");
                        string newLocation = Validation("Enter new location or leave empty to keep the current location: ");
                        if (!string.IsNullOrWhiteSpace(newLocation))
                        {
                            studio.StudioLocation = newLocation;
                        }
                        string newYearInput = Validation("Enter new year or leave empty to keep the current year: ");
                        if (int.TryParse(newYearInput, out int newYear) && newYear >= 1900 && newYear <= 2024)
                        {
                            studio.StudioYear = newYear;
                        }
                        movie.Studios.Add(studio);
                        Console.WriteLine($"Studio: {studio.StudioName} - movie: {movie.Name}");
                    }
                    else
                    {
                        Console.WriteLine("Studio not found");
                    }
                }
                   
                Console.WriteLine("do you want to update another studio for the movie? y/n ");

                AddNewStudio= Console.ReadLine()?.ToLower() == "y"; 
            }
            _movieRepository.AddMovie(movie);
            Console.WriteLine("Movie added with updated studio");

        }
        //get all movies
        public void GetMovies()
        {
            var movies = _movieRepository.GetAllMovies();
            foreach(var movie in movies)
            {
                Console.WriteLine($"Id: {movie.ID}, Name : {movie.Name}, Year: {movie.Year}, Description: {movie.Description}, Genre: {movie.Genre}");
                foreach(var studio in movie.Studios)
                {
                    Console.WriteLine($"For the movie: {movie.Name} There is: Studio: {studio.StudioName}, Location: {studio.StudioLocation}");
                }
            }
        }
        //uodate the movies
        public void UpdateAnyMovie()
        {
            string name = Validation("Please enter the movie you want to update ");
            var movie = _movieRepository.GetMovie(name);

            if (movie != null)
            {
                Console.WriteLine("Enter new movie name or leave empty to keep the current name ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    movie.Name = newName;
                }
                Console.WriteLine("Enter new year or leave empty to keep the current year ");
                string newYear = Console.ReadLine();

                if (!string.IsNullOrEmpty(newYear) && int.TryParse(newYear, out int year) && year >= 1900 && year <= 2024)
                {
                    {
                        movie.Year = year;
                    }
                }

                    Console.WriteLine("Enter new movie description or leave empty to keep the current description: ");
                    string newDescription = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newDescription))
                {
                        movie.Description = newDescription;
                    }

                Console.WriteLine("Enter new movie genre or leave empty to keep the current genre: ");
                string newGenre = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newGenre))
                {
                    movie.Genre = newGenre;
                }


            }
            _movieRepository.UpdateMovie(movie);
            Console.WriteLine("Movie updated");
        }
        //delete movie by name
        public void DeleteAnyMovie()
        {
            string name = Validation("Enter the name of the movie you want to delete ");
            _movieRepository.DeleteMovie(name);
        }
        public void DisplayMoviesByGenre()
        {
            string genre = Validation("Enter the genre you want to filter the movies by: ");
            var movies = _movieRepository.GetMoviesByGenre(genre);
            if (movies != null)
            {
                Console.WriteLine($"Movies with the {genre} you chose are: ");
                foreach(var movie in movies)
                {
                    Console.WriteLine($"Name: {movie.Name}, Year: {movie.Year},Description: {movie.Description}, Genre: {movie.Genre}");

                }
            }
        }

        //filter movies by genre and year
        public void DisplayMoviesByGenreAndYear()
        {
            string genre = Validation("Enter the genre ypu want to filter the movies by: ");
            int year = ValidationInt("Enter the year you want to filter the movies by: ", 1900, 2024);
            var movies = _movieRepository.GetMoviesByGenreAndYear(genre, year);
            if(movies != null)
            {
                Console.WriteLine("The movies are");
                foreach(var movie in movies)
                {
                    Console.WriteLine($"Name: {movie.Name}, Year: {movie.Year},Description: {movie.Description}, Genre: {movie.Genre}");
                }
            }
        }

        //filter movies by year
        public void DisplayMoviesByYear()
        {
            int year = ValidationInt("Enter the year you want to filter the movies: ", 1900, 2024);
            var movies = _movieRepository.GetMoviesbyYear(year);
            if (movies != null)
            {
                Console.WriteLine("The movies are: ");
                foreach (var movie in movies)
                {
                    Console.WriteLine($"Name: {movie.Name}, Year: {movie.Year},Description: {movie.Description}, Genre: {movie.Genre}");
                }
            }
        }
        //top ten movies by rating
        public void GetTopTenMovies()
        {
            var movies = _movieRepository.GetTopTenMovies();
            if(movies != null)
            {
                foreach(var movie in movies)
                {

                    Console.WriteLine($"Name: {movie.Name}, Year: {movie.Year},Description: {movie.Description}, Genre: {movie.Genre}");
                }
            }
        }
        //filter the movies by year range with a start year and end year. The method will display the movies that have their year between the start and end date.
        public void GetMoviesByYearRange()
        {
            int startYear = ValidationInt("Enter the start year for the movie: ");
            int endYear = ValidationInt("Enter the end year for the movie: ");
            var movies = _movieRepository.GetMoviesByYearRange(startYear, endYear);

            if(movies != null)
            {
                Console.WriteLine($"Movie between {startYear} and {endYear} are: ");
                foreach(var movie in movies)
                {
                    Console.WriteLine($"Name: {movie.Name}, Year: {movie.Year},Description: {movie.Description}, Genre: {movie.Genre}");
                }
            }
            }
        //validating the string input
        public string Validation(string message)
        {
            Console.Write(message);
            string inputUser = Console.ReadLine();
            while (inputUser == null)
            {
                Console.Write("Please introduce the required information!");
                Console.Write(message);
                inputUser = Console.ReadLine();
            }
            return inputUser;
        }
        //validating the int input
        public int ValidationInt(string message, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            Console.WriteLine(message);
            string inputUser = Console.ReadLine();
            int intValue;
            while (!int.TryParse(inputUser, out intValue) || intValue < minValue || intValue > maxValue)
            {
                Console.WriteLine($"The entry must be between {minValue} and {maxValue}");
                Console.Write(message);
                inputUser = Console.ReadLine();
            }
            return intValue;
        }


    }
}

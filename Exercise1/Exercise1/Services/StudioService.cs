using Exercise1.Migrations;
using Exercise1.Models;
using Exercise1.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Services
{
    public class StudioService
    {
        private readonly IStudioRepository _studioRepository;
        private readonly IMovieRepository _movieRepository;

        public StudioService(IStudioRepository studioRepository, IMovieRepository movieRepository)
        {
            _studioRepository = studioRepository;
            _movieRepository = movieRepository;
        }

        public void AddNewStudio()
        {
            var studio = new Studio
            {
                StudioName = Validation("Enter the studio name: "),
                StudioYear = ValidationInt("Enter the studio year: "),
                StudioLocation = Validation("Enter the studio location: "),
                Movies = new List<Movie>()

            };

            bool AddMovieForStudio = true;
            while (AddMovieForStudio)
            {
                string movieName = Validation("Enter the movie name to associate with the studio: ");
                if (string.IsNullOrEmpty(movieName))
                {
                    var movie = _movieRepository.GetMovie(movieName);

                    if (movie == null)
                    {
                        Console.WriteLine("Movie was not found.Enter y for yes and n for no.");
                        if(Console.ReadLine()?.ToLower() == "y")
                        {
                            movie = new Movie
                            {
                                Name = movieName,
                                Year = ValidationInt("enter the year of the movie: "),
                                Description = Validation("Enter the description of the movie: "),
                                Genre = Validation("Enter the genre of the movie "),
                                Studios = new List<Studio>()
                            };
                            _movieRepository.AddMovie(movie);
                            Console.WriteLine("New movie added!");
                        }
                        else
                        {
                            continue;
                        }
                    }

                    studio.Movies.Add(movie);
                    Console.WriteLine($"The movie {movie.Name} was made at {studio.StudioName}");
                }

                Console.WriteLine("Do you want to add another movie? y/n");
                AddMovieForStudio = Console.ReadLine()?.ToLower() == "y";
            }
            _studioRepository.AddStudio(studio);
            Console.WriteLine("studio saved in the db!");
        }

        public void GetAllStudios()
        {
            var studios = _studioRepository.GetAll();

            foreach (var studio in studios)
            {
                Console.WriteLine($"Studio name: {studio.StudioName},Year: {studio.StudioYear},Location:{studio.StudioLocation},Studio id: {studio.StudioId}"); 
                foreach (var movie in studio.Movies)
                {
                    Console.WriteLine($"For the studio: {studio.StudioName} there is : movie name: {movie.Name}");
                }
            }
        }
        public void DeleteStudios()
        {
            GetAllStudios();
            int studio = ValidationInt("Enter the id of the studio you want to delete!");
            _studioRepository.DeleteStudio(studio);
            Console.WriteLine("Studio deleted!");
        }
        public void UpdateStudios()
        {
            string studio = Validation("Enter the studio name you want to update: ");
            var studios = _studioRepository.GetStudio(studio);

            if (studios != null)
            {
                Console.WriteLine("Enter the new studio name or leave empty to keep the current name; ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    studios.StudioName = newName;
                }

                Console.WriteLine("Enter new year or leave empty to keep the current year ");
                string newYear = Console.ReadLine();

                if (!string.IsNullOrEmpty(newYear) && int.TryParse(newYear, out int year) && year >= 1900 && year <= 2024)
                {
                    {
                        studios.StudioYear = year;

                    }
                }

                Console.WriteLine("Enter the new studio location or leave empty to keept the current location: ");
                string newLocation = Console.ReadLine();
                if(!string.IsNullOrWhiteSpace(newLocation))
                {
                    studios.StudioLocation = newLocation;
                }

                _studioRepository.UpdateStudio(studios);
                Console.WriteLine("Studio updates");
            }
        }
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

using MovieCollection.model;
using System;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Movie> movies = new List<Movie>();

            void addMovie(string id, string name, int year, int duration, string description)
            {
                Movie movie = new(id, name, year, duration, description);
                movies.Add(movie);
                Console.WriteLine($"Movie with id {id} added successfully.");

            }

            void UpdateMovie(string id, string name, int year, int duration, string description)
            {
                var movieToUpdate = movies.Find(movie => movie.Id == id);
                if (movieToUpdate != null)
                {
                    movieToUpdate.Name = name;
                    movieToUpdate.Year = year;
                    movieToUpdate.Duration = duration;
                    movieToUpdate.Description = description;
                    Console.WriteLine($"Movie with id {id} updated successfully.");
                }
                else
                {
                    Console.WriteLine($"Movie with id {id} not found.");
                }
            }

            void DeleteMovie(string id)
            {
                var movieToDelete = movies.Find(movie => movie.Id == id);
                if (movieToDelete != null)
                {
                    movies.Remove(movieToDelete);
                    Console.WriteLine($"Movie with id {id} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Movie with id {id} not found.");
                }
            }

            Movie SearchByTitle(string title)
            {
                var movie = movies.Find(movie => movie.Name == title);
                return movie;
            }

            void SaveToFile(List<Movie> movies, string filePath)
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(movies, options);
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine("Movies saved to file successfully.");
            }

            List<Movie> LoadFromFile(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found.");
                    return new List<Movie>();
                }

                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Movie>>(jsonString) ?? new List<Movie>();
            }

            void ConsoleMenu()
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1: Add Movie");
                    Console.WriteLine("2: Update Movie");
                    Console.WriteLine("3: Delete Movie");
                    Console.WriteLine("4: Search by Title");
                    Console.WriteLine("5: Save to File");
                    Console.WriteLine("6: Load from File");
                    Console.WriteLine("all: See all movies");
                    Console.WriteLine("7: Exit");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("Enter movie ID:");
                            string id = Console.ReadLine();
                            Console.WriteLine("Enter movie name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter movie year:");
                            int year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter movie duration (in minutes):");
                            int duration = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter movie description:");
                            string description = Console.ReadLine();
                            addMovie(id, name, year, duration, description);
                            break;
                        case "2":
                            Console.WriteLine("Enter the ID of the movie you want to update:");
                            id = Console.ReadLine();
                            Console.WriteLine("Enter new movie name:");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter new movie year:");
                            year = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new movie duration (in minutes):");
                            duration = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new movie description:");
                            description = Console.ReadLine();
                            UpdateMovie(id, name, year, duration, description);
                            break;
                        case "3":
                            Console.WriteLine("Enter the ID of the movie you want to delete:");
                            id = Console.ReadLine();
                            DeleteMovie(id);
                            break;
                        case "4":
                            Console.WriteLine("Enter movie title to search:");
                            name = Console.ReadLine();
                            var movie = SearchByTitle(name);
                            if (movie != null)
                            {
                                Console.WriteLine(movie.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Movie not found.");
                            }
                            break;
                        case "5":
                            Console.WriteLine("Enter file path to save movies:");
                            string filePath = Console.ReadLine();
                            SaveToFile(movies, filePath);
                            break;
                        case "6":
                            Console.WriteLine("Enter file path to load movies:");
                            filePath = Console.ReadLine();
                            movies = LoadFromFile(filePath);
                            Console.WriteLine("Movies loaded successfully.");
                            break;
                        case "all":
                            movies.ForEach(m => Console.WriteLine(m.ToString()));
                            break;
                        case "7":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }

            ConsoleMenu();

        }
    }
}
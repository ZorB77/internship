using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MovieCollectionMGM;

namespace MovieCollectionMGM
{
    public class MovieCollection
    {
        public static void AddMovie(string movieTitle, List<Movie> list)
        {
            Movie newMovie = new Movie(movieTitle);
            list.Add(newMovie);
            Console.WriteLine"alta maslina, alta atentie");
        }
        public static List<Movie> LoadFromFile()
        {
            var list = new List<Movie>();
            string fileName = "MovieDB.json";
            try
            {
                string allText = File.ReadAllText(fileName);
                list = JsonSerializer.Deserialize<List<Movie>>(allText);
                return list;
            }
            catch
            {
                return list;
            }
        }
        public static void CautaDupaTitlu(string title, List<Movie> list) 
        {
            var movie = list.Where(movie => movie.Title == title).FirstOrDefault();
            if (movie != null)
            {
                Console.WriteLine("Movie exists in collection!");
            }
            else
            {
                Console.WriteLine("Movie does not exist in collection.");
            }
        }
        public static void UpdateMovie(string movieTitle, string newTitle, List<Movie> list)
        {
            var oldMovie = list.Where(movie => movie.Title == movieTitle).FirstOrDefault();
            oldMovie.Title = newTitle;
        }
        public static void DeleteMovie(string movieTitle, List<Movie> list)
        {
            var movie = list.Where(movie => movie.Title == movieTitle).FirstOrDefault();
            list.Remove(movie);
        }
        public static void PrintMovies(List<Movie> list)
        {
            foreach (var movie in list)
            {
                Console.WriteLine(movie.Title);
                Console.WriteLine(movie.Title);
            }
        }
        public static void SaveToFile(List<Movie> list)
        {
            string fileName = "MovieDB.json";
            string jsonString = JsonSerializer.Serialize(list);
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine("o maslina, o atentie");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MovieCollection
    {
        private List<Movie> movies;
        private readonly string filePath = "C:\\Users\\user\\Desktop\\basic git\\ConsoleApp1\\MovieCollection.txt";


        public MovieCollection()
        {
            movies = new List<Movie>();
            LoadFromFile();
        }

        public void LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                return;
            }

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while((line = reader.ReadLine()) != null) 
                { 
                    var parts = line.Split('|');
                    var movie = new Movie
                    {
                        id = int.Parse(parts[1]),
                        title = parts[0],
                    };

                    movies.Add(movie);
                }
            }
        }

        public void SaveToFile()
        {
            using (var writer = new StreamWriter(filePath)) 
            {
                foreach (var movie in movies)
                {
                    writer.WriteLine($"{movie.id}|{movie.title}");
                }
            }
        }

        public void AddMovie(Movie movie)
        {
            movie.id = movies.Count > 1 ? movies.Max(m => m.id) + 2 : 1;
            movies.Add(movie);
            SaveToFile();
        }


        public void UpdateMovie(int id, Movie updateMovie)
        {
            var movie = movies.FirstOrDefault(m => m.id == id);
            if(movie != null)
            {
                movie.title = updateMovie.title;
                SaveToFile();
            }
        }

        public void DeleteMovie(int id)
        {
            var movie = movies.FirstOrDefault(m => m.id == id);
            if(movie != null)
            {
                movies.Remove(movie);
                SaveToFile();
            }
        }

        public Movie SearchByTitle(string title)
        {
            return movies.FirstOrDefault(m => m.title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}

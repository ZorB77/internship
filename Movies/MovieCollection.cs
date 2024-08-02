using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    class MovieCollection
    {
        List<Movie> movies;
        public MovieCollection() { }

        public void AddMovie(int id, string title, string producer)
        {
            Movie movie = new Movie(id, title, producer);
            movies.Add(movie);
        }
        public void DeleteMovie(int index)
        {
            movies.Remove(movies[index]);
        }
        public void UpdateMovie(int index, int id, string title, string producer)
        {
            DeleteMovie(index);
            AddMovie(id,title, producer);
        }

        public void SearchByTitle(string title)
        {

            var foundMovies = movies.Where(m => m.title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var movie in foundMovies)
            {
                Console.WriteLine(movie.title);
            }
        }
        public void SaveToFile(string path, string data)
        {

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(data);
            }
        }

        public string LoadFromFile(string file, string content)
        {
            string readText;
            using (StreamReader reader = new StreamReader(file))
            {
                readText = reader.ReadToEnd();
            }

            return readText;
        }

    }
}

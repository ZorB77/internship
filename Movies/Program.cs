using System;
using System.ComponentModel;
using Movies;

namespace Programs

{
    class Program {

        static void Main(string[] args) {

            MovieCollection movieCollection = new MovieCollection();

            Console.WriteLine("Choose an option: ");
            Console.WriteLine("1. Load movies ");
            Console.WriteLine("2. Add movie ");
            Console.WriteLine("3. Delete movie ");
            Console.WriteLine("4. Update movie ");
            Console.WriteLine("5. Search movie ");
            Console.WriteLine("6. Save ");
            Console.WriteLine("0. Exit");
            Console.Write("r\nSelect an option;");


            switch(Console.ReadLine())
            {

                case "1":
                    AddMovie(MovieCollection movieCollection);
                    break;
                case "2":
                    UpdateMovie(MovieCollection movieCollection);
                    break;
            }
        }

        private static void UpdateMovie(MovieCollection movieCollection1, MovieCollection movieCollection2)
        {
            throw new NotImplementedException();
        }

        private static void AddMovie(MovieCollection movieCollection)
        {
            try
            {
                int id = 2;
                Console.WriteLine("Enter a movie title to be added: ");
                string title = Console.ReadLine();
                Console.WriteLine("Enter the producer of the movie: ");
                string producer = Console.ReadLine();
                Movie movie = null;
                if (title != null && producer != null)
                {
                    movieCollection.AddMovie(id,title,producer);
                }
                else
                {
                    Console.WriteLine("Error: title or producer invalid");
                    
                }
 
            } catch (Exception ex) { 
                ex.ToString();
            }


        }
    }

}
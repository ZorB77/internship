// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text;

class Program
{
    public static void Main()
    {
        string path = @"C:\Users\buzea\Desktop\exemplu\movies.txt";
        string[] multipleMovies = { "Insidious", "The Maze Runner", "The Paramedic" };
       
        File.WriteAllLines(path, multipleMovies);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Insidious");
        sb.AppendLine("The Maze Runner");
        sb.AppendLine("The Paramedic");
        File.WriteAllText(path, sb.ToString());
        string[] existingMovies = File.ReadAllLines(path);
        //options
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1.Add a Movie");
        Console.WriteLine("2.Update a Movie");
        Console.WriteLine("3.Delete a Movie");
        Console.WriteLine("4.Search by title");
        Console.WriteLine("5.Save To File");
        Console.WriteLine("6.Load From File");

        int selectedOption;
        if (int.TryParse(Console.ReadLine(), out selectedOption))
        {
            switch (selectedOption)
            {
                case 1:
                    Console.WriteLine("Enter the name of the movie to add:");
                    string movieName = Console.ReadLine();
                  // File.AppendAllText(path, movieName + Environment.NewLine);
                    //Console.WriteLine("Movie added successfully");
                    string[] addedMovies = new string[existingMovies.Length + 1];
                    Array.Copy(existingMovies, addedMovies, existingMovies.Length);
                    addedMovies[existingMovies.Length] = movieName;
                    File.WriteAllLines(path, addedMovies);
                    Console.WriteLine("The movie was added");
                    break;
                case 2:
                    Console.WriteLine("Update the movie with the name:");
                    string movieToUpdate = Console.ReadLine();
                    int movieIndexUpdate = Array.IndexOf(existingMovies, movieToUpdate);
                    if (movieIndexUpdate != -1)
                    {
                        Console.WriteLine("Enter the new movie name:");
                        string newMovie = Console.ReadLine();
                        existingMovies[movieIndexUpdate] = newMovie;
                        File.WriteAllLines(path, existingMovies);
                        Console.WriteLine("Movie updated!");
                    }
                    else
                    {
                     Console.WriteLine("movie not found.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Delete the name of the Movie: ");
                    string movieToDelete = Console.ReadLine();
                    int movieIndexDelete = Array.IndexOf(existingMovies,movieToDelete);
                    if(movieIndexDelete != -1)
                    {
                        string[] deletedMovies = new string[existingMovies.Length-1];
                        Array.Copy(existingMovies, deletedMovies, movieIndexDelete);
                        Array.Copy(existingMovies, movieIndexDelete + 1, deletedMovies, movieIndexDelete, existingMovies.Length - movieIndexDelete - 1);
                        File.WriteAllLines(path, deletedMovies);
                        Console.WriteLine("Movie deleted!");
                    }
            break;
                case 4:
                    Console.WriteLine("Search a movie by title");
                    break;
                case 5:
                    Console.WriteLine("Save to a file");
                    break;
                case 6:
                    Console.WriteLine("Load From a file");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
  //  public void UpdateMovieName(string newAccountHolderName)
  //  {
    //    AccountHolderName = newAccountHolderName;
  //  }
}
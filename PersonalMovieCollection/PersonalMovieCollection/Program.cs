
using System.Transactions;

public class Movie
{
    private string title;
    private string description;
    private int year;

    public Movie(string title, string description, int year) { 
        this.title = title;
        this.description = description;
        this.year = year;
    }

    public string getTitle()
    {
        return title; 
    }

    public string getDescription()
    {
        return description;
    }

    public int getYear()
    {
        return year;
    }

    public string getString()
    {
        return title + ";" + description + ";" + year;
    }

};



namespace PersonalMovieCollection
{
    class Program
    {
        static List<Movie> movies = new List<Movie>();

        static void readFromFile(string fileName)
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader(fileName);
                line = sr.ReadLine();
                while (line != null)
                {
                    //Console.WriteLine(line);
                    string[] movie_information = line.Split(';');
                    /*foreach (string movie in movie_information)
                    {
                        Console.WriteLine(movie);
                    }*/
                    Movie movie = new Movie(movie_information[0], movie_information[1], Int32.Parse(movie_information[2]));
                    movies.Add(movie);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        static void writeToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach(Movie movie in movies)
                {
                    writer.WriteLine(movie.getString());
                }
            }
        }

        static void addMovie()
        {
            Console.WriteLine("Add a movie!\n");
            Console.WriteLine("Enter the title:");
            string title = Console.ReadLine();
            while (title == "") {
                Console.WriteLine("Title cannot be empty!");
                Console.WriteLine("Enter the title:");
                title = Console.ReadLine();
            }

            Console.WriteLine("Enter the description:");
            string description = Console.ReadLine();
            while (description == "")
            {
                Console.WriteLine("Description cannot be empty!");
                Console.WriteLine("Enter the description:");
                description = Console.ReadLine();
            }

            Console.WriteLine("Enter the year:");
            string year = Console.ReadLine();
            while (year == "")
            {
                Console.WriteLine("Year cannot be empty!");
                Console.WriteLine("Enter the year:");
                year = Console.ReadLine();
            }

            Console.WriteLine("\n\nThe final data is:");
            Console.WriteLine("Title:" + title);
            Console.WriteLine("Description:" + description);
            Console.WriteLine("Year:" + year);

            Console.WriteLine("Do you want to add this movie? yes/no");
            string input = Console.ReadLine(); 
            if (input == "yes")
            {
                int year_to_string = Int32.Parse(year);
                Movie movie = new Movie(title, description, year_to_string);
                movies.Add(movie);

            }
            else
            {
                Console.WriteLine("Back to the main menu.");
            }

        }

        static void printAllMovies()
        {
            if (movies.Capacity == 0)
            {
                Console.WriteLine("There are no saved movies.    ");
            }
            else
            {
                Console.WriteLine("The list of movies is:");
                int n = 1;
                foreach (Movie movie in movies)
                {
                    Console.WriteLine(n + ". " + movie.getTitle() + ": " + movie.getDescription() + " Release date: " + movie.getYear() + '\n');
                    n++;
                }
            }
        }   
         
        static void deleteMovie(int position)
        {
            movies.RemoveAt(position-1);
        }

        static void updateMovie(int position, string title, string description, int year)
        {
            position = position - 1;
            movies[position] = new Movie(title, description, year);
        }

        static bool searchMovie(string title)
        {
            foreach(Movie movie in movies)
            {
                if (movie.getTitle() == title) return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            readFromFile("C:\\Users\\admin\\Documents\\internship\\PersonalMovieCollection\\PersonalMovieCollection\\movies.txt");

            Console.WriteLine("Welcome to personal movie collection! Choose an option:\n");
            Console.WriteLine("1. Add a movie.\n");
            Console.WriteLine("2. Update a movie.\n");
            Console.WriteLine("3. Delete a movie.\n");
            Console.WriteLine("4. See the list with all movies.\n");
            Console.WriteLine("5. Search for a movie.\n");
            Console.WriteLine("0. Exit application.\n\n");
            Console.WriteLine("Your choice:");
            
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "0")
                {
                    writeToFile("C:\\Users\\admin\\Documents\\internship\\PersonalMovieCollection\\PersonalMovieCollection\\movies.txt");
                    break;
                }
                else if (input == "1")
                {
                    addMovie();
                }
                else if (input == "2")
                {
                    printAllMovies();
                    Console.WriteLine("Which movie do you want to update?");
                    Console.WriteLine("Your option:");
                    int position = Int32.Parse(Console.ReadLine());
                    string title, description;
                    int year;
                    Console.WriteLine("Enter the new title:");
                    title = Console.ReadLine();
                    Console.WriteLine("Enter the new description:");
                    description = Console.ReadLine();
                    Console.WriteLine("Enter the new year:");
                    year = Int32.Parse(Console.ReadLine());

                    updateMovie(position, title, description, year);
                    Console.WriteLine("Movie successfully updated!");

                }
                else if (input == "3")
                {
                    printAllMovies();
                    Console.WriteLine("Which movie do you want to delete?");
                    Console.WriteLine("Your option:");
                    string position = Console.ReadLine();
                    deleteMovie(Int32.Parse(position));
                    Console.WriteLine("The movie was successfully deleted!");
                }
                else if (input == "4")
                {
                    printAllMovies();
                }
                else if (input == "5") 
                {
                    Console.WriteLine("Enter the title of the movie:");
                    string title = Console.ReadLine();
                    if (searchMovie(title))
                    {
                        Console.WriteLine("The movie exists in the list.");
                    }
                    else 
                    {
                        Console.WriteLine("The movie is not in the list.");
                    }

                }

                Console.WriteLine("Your choice:");
                input = Console.ReadLine();
            }
            


        }
    }
}
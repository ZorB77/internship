using ConsoleApp1;

MovieCollection movieCollection = new MovieCollection();
bool running = true;

while(running)
{
    Console.WriteLine("1 - Add movie");
    Console.WriteLine("2 - Update movie");
    Console.WriteLine("3 - Delete movie");
    Console.WriteLine("4 - Search movie by title");

    Console.WriteLine("Select option:");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            AddMovie(movieCollection);
            break;
            break;
        case "2":
            UpdateMovie(movieCollection);
            break;
        case "3":
            DeleteMovie(movieCollection);
            break;
        case "4":
            SearchMovieByTitle(movieCollection);
            break;
        case "5":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option. Try again!\n");
            break;
    }
}

static void AddMovie(MovieCollection movieCollection)
{
    var movie = new Movie();
    Console.WriteLine("Enter title: ");
    movie.title = Console.ReadLine();

    movieCollection.AddMovie(movie);
    Console.WriteLine("Movie added succesfully\n");
}

static void UpdateMovie(MovieCollection movieCollection)
{
    Console.WriteLine("Enter movie id to update: ");
    int id = int.Parse(Console.ReadLine());

    var updatedMovie = new Movie();
    Console.WriteLine("Enter title:  ");
    updatedMovie.title = Console.ReadLine();

    movieCollection.UpdateMovie(id, updatedMovie);
    Console.WriteLine("Movie updated succesfully\n");
}

static void DeleteMovie(MovieCollection movieCollection)
{
    Console.WriteLine("Enter movie id to delete: ");
    int id = int.Parse(Console.ReadLine());

    movieCollection.DeleteMovie(id);
    Console.WriteLine("Movie deleted succesfully\n");
}

static void SearchMovieByTitle(MovieCollection movieCollection)
{
    Console.WriteLine("Enter movie title to search: ");
    var title = Console.ReadLine();
    var movie = movieCollection.SearchByTitle(title);
    if(movie != null)
    {
        Console.WriteLine("Movie found");
        Console.WriteLine(movie);
        Console.WriteLine("\n");
    }
    else
    {
        Console.WriteLine("Movie not found\n");
    }
}

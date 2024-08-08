using ETMovies.DatabaseContext;
using ETMovies.Models;
using ETMovies.Service;

class Program
{
    static void Main()

    {

        MyDbContext myDbContext = new MyDbContext();
        DataService service = new DataService(myDbContext);

        
        while (true) {
 
            Console.WriteLine("Menu");
            Console.WriteLine("1. Movies");
            Console.WriteLine("2. Persons");
            Console.WriteLine("3. Roles");
            Console.WriteLine("4. Reviews");
            Console.WriteLine("5. Filter movies by year");
            Console.WriteLine("6. Sort movies by name and category");
            Console.WriteLine("7. Get the rating of a movie");
            Console.WriteLine("8. Top ten movies");
            Console.WriteLine("0. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    MoviesMenu(service);
                    break;
                case "2":
                    PersonsMenu(service);
                    break;
                case "3":
                    RolesMenu(service);
                    break;
                case "4":
                    ReviewsMenu(service);
                    break;
                case "5":
                    FilterMovies(service);
                    break;
                case "6":
                    SortMovies(service);
                    break;
                case "7":
                    GetRatingForMovie(service);
                    break;
                case "8":
                    GetTopTenMovies(service);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again");
                    break;


            }
        }

    
    }

    private static void GetTopTenMovies(DataService service)
    {
        var list = service.TopTenMoviesByRating();
        foreach (var movie in list)
        {
            Console.WriteLine($"{movie.Title}");
        }

    }

    private static void GetRatingForMovie(DataService service)
    {
        Console.WriteLine("Enter the movie id to get a rating: ");

        int id = int.Parse(Console.ReadLine());
        Console.WriteLine($"{service.GetAverageRating(id)}");
    }

    private static void SortMovies(DataService service)
    {
        var list = service.SortMoviesByNameAndGenre();
        foreach (var movie in list)
        {
            Console.WriteLine($"{movie.Title}");
        }
    }

    private static void FilterMovies(DataService service)
    {
        Console.WriteLine("Enter the first year");
        int startyear = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second year");
        int endyear = int.Parse(Console.ReadLine());
        
        var filteredmovies = service.GetMoviesByDateRange(startyear, endyear);
        foreach (var movie in filteredmovies)
        {
            Console.WriteLine($"{movie.Title}");
        }
    }
    #region MoviesPart
    private static void MoviesMenu(DataService service)
    {
        Console.Clear();

        while (true)
        {

            Console.WriteLine("Movies Menu");
            Console.WriteLine("1. Show all movies");
            Console.WriteLine("2. Add a new movie");
            Console.WriteLine("3. Update a movie");
            Console.WriteLine("4. Delete a movie");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option: ");
            

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    showAllMovies(service);
                    break;
                case "2":
                    addMovie(service);
                    break;
                case "3":
                    updateMovie(service);
                    break;
                case "4":
                    deleteMovie(service);
                    break;
                case "0":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;


            }
        }
    }

    private static void deleteMovie(DataService service)
    {
        Console.WriteLine("You want to delete a movie by ID or title?");
        Console.WriteLine("Choose 1 for ID or 2 for title");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1) {
            Console.WriteLine("Enter the ID of the movie you want to delete: ");
            int idToDelete = int.Parse(Console.ReadLine());
            service.DeleteMovie(idToDelete);
            Console.WriteLine("The movie was succesfully deleted");
        }
        else if (choice == 2)
        {
            Console.WriteLine("Enter the title of the movie you want to delete: ");
            string title = Console.ReadLine();
            service.DeleteMovieByTitle(title);
            Console.WriteLine("The movie was succesfully deleted");
        }
        else {
            Console.WriteLine("Invalid choice for deleting"); }
    
    }

    private static void updateMovie(DataService service)
    {
        Console.WriteLine("Soon to pe implemented");
        Console.WriteLine("Soon to pe implemented");
        Console.WriteLine("Soon to pe implemented");
        Console.WriteLine("Soon to pe implemented");
    }

    private static void addMovie(DataService service)
    {
        Console.WriteLine("Enter the movie title: ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the movie description: ");
        string description = Console.ReadLine();
        Console.WriteLine("Enter the movie year: ");
        int year = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the movie genre: ");
        string genre = Console.ReadLine();

        Movie movie = new Movie(title, description, year, genre);

        service.AddMovie(movie);
    }

    private static void showAllMovies(DataService service)
    {
        var movies = service.GetMovies();
        foreach (var item in movies)
        {

            Console.WriteLine($"{item.Title}");
        }
    }

    #endregion



    private static void RolesMenu(DataService service)
    {
        Console.Clear();

        while (true)
        {

            Console.WriteLine("Roles Menu");
            Console.WriteLine("1. Show all roles");
            Console.WriteLine("2. Add a new role");
            Console.WriteLine("3. Update a role");
            Console.WriteLine("4. Delete a role");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option: ");


            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    showAllRoles(service);
                    break;
                case "2":
                    addRole(service);
                    break;
                case "3":
                    updateMovie(service);
                    break;
                case "4":
                    deleteMovie(service);
                    break;
                case "0":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;


           }
       
    }
}

    private static void addRole(DataService service)
    {
        throw new NotImplementedException();
    }

    private static void showAllRoles(DataService service)
    {
        throw new NotImplementedException();
    }

    private static void PersonsMenu(DataService service)
    {
        throw new NotImplementedException();
    }

    private static void ReviewsMenu(DataService service)
    {
        Console.Clear();

        while (true)
        {

            Console.WriteLine("Reviews Menu");
            Console.WriteLine("1. Show all reviews");
            Console.WriteLine("2. Add a new review");
            Console.WriteLine("3. Update a review");
            Console.WriteLine("4. Delete a review");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option: ");


            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    showAllReviews(service);
                    break;
                case "2":
                    addReview(service);
                    break;
                case "3":
                    updateReview(service);
                    break;
                case "4":
                    deleteReview(service);
                    break;
                case "0":
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Invalid option");
                    break;


            }
        }
    
}

    private static void addReview(DataService service)
    {
        Console.WriteLine("Enter the ID of the movie you want to leave a review");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the rating for this movie (0-100): ");
        int rating = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter your comment about the movie: ");
        string comment = Console.ReadLine();

        Review review = new Review(rating, comment);

        service.AddReview(review, id);
    }

    private static void deleteReview(DataService service)
    {
        throw new NotImplementedException();
    }

    private static void updateReview(DataService service)
    {
        throw new NotImplementedException();
    }

    private static void showAllReviews(DataService service)
    {
        var items = service.GetReviews();
        foreach (var item in items)
        {

            Console.WriteLine($"{item.Rating}");
        }
    }
}
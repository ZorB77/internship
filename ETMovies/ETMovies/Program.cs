using ETMovies.DatabaseContext;
using ETMovies.Models;
using ETMovies.Service;
using Microsoft.IdentityModel.Tokens;
using System;

class Program
{
    static void Main()

    {

        MyDbContext myDbContext = new MyDbContext();
        DataService service = new DataService(myDbContext);


        while (true)
        {

            Console.WriteLine("Menu");
            Console.WriteLine("1. Movies");
            Console.WriteLine("2. Persons");
            Console.WriteLine("3. Roles");
            Console.WriteLine("4. Reviews");
            Console.WriteLine("5. Filter movies by year");
            Console.WriteLine("6. Sort movies by name and category");
            Console.WriteLine("7. Get the rating of a movie");
            Console.WriteLine("8. Top ten movies");
            Console.WriteLine("9. Filter actors by role");
            Console.WriteLine("10. Filter persons by age");
            Console.WriteLine("11. Studios");
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
                case "9":
                    FilterActorsByRole(service);
                    break;
                case "10":
                    FilterPersonsByAge(service);
                    break;
                case "11":
                    StudiosMenus(service);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again");
                    break;


            }
        }


    }

    private static void StudiosMenus(DataService service)
    {
        Console.Clear();

        while (true)
        {

            Console.WriteLine("Studios Menu");
            Console.WriteLine("1. Show all studios");
            Console.WriteLine("2. Add a new studio");
            Console.WriteLine("3. Update a studio");
            Console.WriteLine("4. Delete a studio");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option: ");


            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    showAllStudios(service);
                    break;
                case "2":
                    addStudio(service);
                    break;
                case "3":
                    updateStudio(service);
                    break;
                case "4":
                    deleteStudio(service);
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

    private static void deleteStudio(DataService service)
    {
        Console.WriteLine("Enter the ID for the studio you want to delete");
        int id = int.Parse(Console.ReadLine());
        try
        {
            service.DeleteStudio(id);
            Console.WriteLine("Successfully deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());

        }
    }

    private static void updateStudio(DataService service)
    {
        try
        {
            Console.WriteLine("Enter the ID of the movie you want to update");
            int studio_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the studio name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the studio year: "); ;
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the studio location: ");
            string location = Console.ReadLine();

            service.UpdateStudio(studio_id, name, year, location);
            Console.WriteLine("Movie updated successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void addStudio(DataService service)
    {
        try
        {
            Console.WriteLine("Enter the studio name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the studio year: ");;
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the studio location: ");
            string location = Console.ReadLine();

            Studio studio = new Studio(name, year, location);
            
            service.AddStudio(studio);
            Console.WriteLine("Added");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void showAllStudios(DataService service)
    {
        var items = service.GetStudios();
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Title}");
        }
    }

    private static void FilterPersonsByAge(DataService service)
    {
        Console.WriteLine("Enter the minimum age: ");
        int mAge = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the max age: ");
        int mxAge = int.Parse(Console.ReadLine());

        DateTime currentDate = DateTime.Today;
        int age = currentDate.Year;
        
        var items = service.FilterPersonsByAge(mAge, mxAge);
        foreach (var item in items) 
            { 
                Console.WriteLine($"{item.FirstName} {item.LastName} - Age: {age- item.Birthdate.Year}"); 
            }
    
    }

    private static void FilterActorsByRole(DataService service)
    {
        Console.WriteLine("Enter the role you want to filter by: ");
        string rolename = Console.ReadLine();
        var filtered = service.FilterActorsByRole(rolename);
        if (filtered.IsNullOrEmpty())
        {
            Console.WriteLine("Sorry, no actors with that role");
        }
        else
        {
            foreach (var actor in filtered)
            {
                Console.WriteLine(actor);
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
        if (choice == 1)
        {
            try
            {
                Console.WriteLine("Enter the ID of the movie you want to delete: ");
                int idToDelete = int.Parse(Console.ReadLine());
                service.DeleteMovie(idToDelete);
                Console.WriteLine("The movie was successfully deleted");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        else if (choice == 2)
        {
            try
            {
                Console.WriteLine("Enter the title of the movie you want to delete: ");
                string title = Console.ReadLine();
                service.DeleteMovieByTitle(title);
                Console.WriteLine("The movie was successfully deleted");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid choice for deleting");
        }

    }

    private static void updateMovie(DataService service)
    {
        try
        {
            Console.WriteLine("Enter the ID of the movie you want to update");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the title of the movie: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the description of the movie: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the year of the movie: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the genre of the movie: ");
            string genre = Console.ReadLine();

            service.UpdateMovie(id, title, description, year, genre);
            Console.WriteLine("Movie updated successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void addMovie(DataService service)
    {
        try
        {
            Console.WriteLine("Enter the movie title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the movie description: ");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the movie year: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the movie genre: ");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter the ID of the studio that produced the movie: ");
            int studio_id = int.Parse(Console.ReadLine());

            Movie movie = new Movie(title, description, year, genre);

            service.AddMovie(movie, studio_id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void showAllMovies(DataService service)
    {
        var movies = service.GetMovies();
        if (movies == null)
        {
            Console.WriteLine("The movies list is null");
            return;
        }
        else
        {
            foreach (var item in movies)
            {
                
                Console.WriteLine($"{item.Title}");
            }
        }
    }

    #endregion

    #region RolesPart

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
                    updateRole(service);
                    break;
                case "4":
                    deleteRole(service);
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

    private static void deleteRole(DataService service)
    {
        Console.WriteLine("Enter the ID for the role you want to delete");
        int id = int.Parse(Console.ReadLine());
        try
        {
            service.DeleteRole(id);
            Console.WriteLine("Successfully deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());

        }
    }

    private static void updateRole(DataService service)
    {
        throw new NotImplementedException();
    }

    private static void addRole(DataService service)
    {
        Console.WriteLine("Enter the name of the role: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the movie for this role: ");
        int mID = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the person for this role: ");
        int pID = int.Parse(Console.ReadLine());

        service.AddRole(name, mID, pID);

        Console.WriteLine("Successfully added??");


    }

    private static void showAllRoles(DataService service)
    {
        var items = service.GetRoles();
        foreach (var item in items)
        {

            Console.WriteLine($"{item.Person.FirstName} {item.Person.LastName} - {item.Name}");
        }
    }

    #endregion

    #region PersonsPart
    private static void PersonsMenu(DataService service)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Persons Menu");
            Console.WriteLine("1. Show all persons");
            Console.WriteLine("2. Add a person");
            Console.WriteLine("3. Update a person");
            Console.WriteLine("4. Delete a person");
            Console.WriteLine("0. Back to main menu");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    showAllPersons(service);
                    break;
                case "2":
                    addPerson(service);
                    break;
                case "3":
                    updatePerson(service);
                    break;
                case "4":
                    deletePerson(service);
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

    private static void deletePerson(DataService service)
    {
        Console.WriteLine("Enter the ID for the person you want to delete");
        int id = int.Parse(Console.ReadLine());
        try
        {
            service.DeletePerson(id);
            Console.WriteLine("Successfully deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());

        }
    }

    private static void updatePerson(DataService service)
    {
        Console.WriteLine("Enter the ID for the person you want to update");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the first name");
        string fname = Console.ReadLine();
        Console.WriteLine("Enter the last name: ");
        string lname = Console.ReadLine();
        Console.WriteLine("Enter the birthday: ");
        DateOnly date = DateOnly.Parse(Console.ReadLine());
        Console.WriteLine("Enter the email: ");
        string mail = Console.ReadLine();

        service.UpdatePerson(id, fname, lname, date, mail);
        Console.WriteLine("Update made successfully");
    }

    private static void addPerson(DataService service)
    {
        Console.WriteLine("Enter the first name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter the last name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter the birthday: ");
        DateOnly date = DateOnly.Parse(Console.ReadLine());
        Console.WriteLine("Enter the email: ");
        string mail = Console.ReadLine();

        Person person = new Person(firstName, lastName, date, mail);

        service.AddPerson(person);
        Console.WriteLine("Person added successfully");
    }

    private static void showAllPersons(DataService service)
    {
        var items = service.GetPersons();
        foreach (var item in items)
        {
            Console.WriteLine($"{item.FirstName} {item.LastName}");
        }
    }

    #endregion

    #region ReviewsPart

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
        Console.WriteLine("Enter the id of the review you want to delete:");
        int id = int.Parse(Console.ReadLine());
        service.DeleteReview(id);
        Console.WriteLine("The review is successfully deleted!");
    }

    private static void updateReview(DataService service)
    {
        Console.WriteLine("Enter the id of the review you want to update: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the new rating");
        int rating = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the new comment about the movie");
        string comment = Console.ReadLine();

        service.UpdateReview(id, rating, comment);
        Console.WriteLine("Update succsessfully");
    }

    private static void showAllReviews(DataService service)
    {
        var items = service.GetReviews();
        foreach (var item in items)
        {

            foreach (var it in item.Reviews)
            {
                Console.WriteLine($"{item.Title} ScoreRating: {it.Rating}");
            }
        }

        /* different printing
         var items = service.GetReviews();
        foreach (var item in items)
        {
            Console.Write($"{item.Title} - Ratings: ");
            bool first = true;
            foreach (var it in item.Review)
            {
                if (!first)
                {
                    Console.Write(", ");
                }

                Console.Write(it.Rating);
                first = false;
            }
            Console.WriteLine();
        }
         */
    }

    #endregion
}

using Exercise1.ConfigDatabase;
using Exercise1.Repository;
using Exercise1.Services;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = @"Server=DESKTOP-FFREVLR;Database=MovieProject;Trusted_Connection=True;";

        using (var context = new MovieContext(connectionString))
        {
            context.Database.Log = Console.WriteLine;

            if (!context.Database.Exists())
            {
                context.Database.Create();
                Console.WriteLine("database created!");
            }
            var movieRepository = new MovieRepository(context);
            var movieService = new MovieService(movieRepository);
            var personRepository = new PersonRepository(context);
            var personService = new PersonService(personRepository);
            var reviewRepository = new ReviewRepostitory(context);
            var reviewService = new ReviewService(reviewRepository,movieRepository);
            var roleRepository = new RoleRepository(context);
            var roleService = new RoleService(roleRepository,movieRepository,personRepository);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. See All Movies");
                Console.WriteLine("3. Update Movie");
                Console.WriteLine("4. Delete Movie");
                Console.WriteLine();
                Console.WriteLine("5. Add Person");
                Console.WriteLine("6. See All Persons");
                Console.WriteLine("7. Update Person");
                Console.WriteLine("8. Delete Person");
                Console.WriteLine();
                Console.WriteLine("9. Add Review");
                Console.WriteLine("10. See All Reviews By Movie name");
                Console.WriteLine("11. Get All Reviews");
                Console.WriteLine("12. Update Review");
                Console.WriteLine("13. Delete Review");
                Console.WriteLine();
                Console.WriteLine("14. Add Role");
                Console.WriteLine("15. See All Roles");
                Console.WriteLine("16. Get Role by Id");
                Console.WriteLine("17. Get Role by Name");
                Console.WriteLine("18. Update Role");
                Console.WriteLine("19. Delete Role");
                Console.WriteLine("20. Get Role by Person");
                Console.WriteLine("21. Get Role by Movie");
                Console.WriteLine();
                Console.WriteLine("22. Filter the movies by genre");
                Console.WriteLine("23. Filter the movies by genre and year.");
                Console.WriteLine("24. Filter the reviews by rating.");
                Console.WriteLine("25. Filter the reviews by keywords from the comments.");
                Console.WriteLine("26. Filter the movies by year.");
                Console.WriteLine("27. Filter the movies year range.");
                Console.WriteLine();
                Console.WriteLine("28. The Average of the reviews.");
                Console.WriteLine("29. Top Ten Movies by rating.");
                Console.WriteLine();
                Console.WriteLine("30. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        movieService.AddNewMovie();
                        break;
                    case "2":
                        movieService.GetMovies();
                        break;
                    case "3":
                        movieService.UpdateAnyMovie();
                        break;
                    case "4":
                        movieService.DeleteAnyMovie();
                        break;
                    case "5":
                        personService.AddNewPerson();
                        break;
                    case "6":
                        personService.GetPersons();
                        break;
                    case "7":
                        personService.UpdatePerson();
                        break;
                    case "8":
                        personService.DeleteAnyPerson();
                        break;
                    case "9":
                        reviewService.AddNewReview();
                        break;
                    case "10":
                        reviewService.GetReviewsByMovieName();
                        break;
                    case "11":
                        reviewService.GetReviews();
                        break;
                    case "12":
                        reviewService.UpdateReview();
                        break;
                    case "13":
                        reviewService.DeleteReview();
                        break;
                    case "14":
                        roleService.AddNewRole();
                        break;
                    case "15":
                        roleService.GetAllRoles();
                        break;
                    case "16":
                        roleService.GetRoleById();
                        break;
                    case "17":
                        roleService.GetRoleByName();
                        break;
                    case "18":
                        roleService.UpdateRole();
                        break;
                    case "19":
                        roleService.DeleteRole();
                        break;
                    case "20":
                        roleService.GetRolesByPerson();
                        break;
                    case "21":
                        roleService.GetRolesByMovieName();
                        break;
                    case "22":
                       movieService.DisplayMoviesByGenre();
                        break;
                    case "23":
                        movieService.DisplayMoviesByGenreAndYear();
                        break;
                    case "24":
                        reviewService.GetReviewsByRating();
                        break;
                    case "25":
                        reviewService.GetReviewsByKeywords();
                        break;
                    case "26":
                        movieService.DisplayMoviesByYear();
                        break;
                    case "27":
                        movieService.GetMoviesByYearRange();
                        break;
                    case "28":
                        reviewService.DisplyAverageRating();
                        break;
                    case "29":
                        movieService.GetTopTenMovies();
                        break;
                    case "30":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

        }

    }
}

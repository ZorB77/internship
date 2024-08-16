using System.ComponentModel.Design;

namespace MovieApplication
{
    class Program
    {
        static void printMainMenu()
        {
            Console.WriteLine("1. Movie menu");
            Console.WriteLine("2. Persons menu");
            Console.WriteLine("3. Reviews menu");
            Console.WriteLine("4. Roles menu");
            Console.WriteLine("0. Exit application.");
        }

        static void Main()
        {
            using MyDBContext db = new MyDBContext();
            MovieService movieService = new MovieService(db);
            PersonService personService = new PersonService(db);
            ReviewService reviewService = new ReviewService(db);
            RoleService roleService = new RoleService(db);
            Console.WriteLine($"The database path of the application is: {db.dbPath}.");
            Console.WriteLine("Welcome to the movie application management!");

            while (true)
            {
                printMainMenu();
                Console.Write("Enter an option:");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    while (true)
                    {
                        movieService.printMenu();
                        Console.Write("Enter an option:");
                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            Console.Write("Enter the name of the movie:");
                            string name = Console.ReadLine();
                            while (name == "")
                            {
                                Console.WriteLine("The name can't be null!");
                                Console.Write("Enter the name of the movie:");
                                name = Console.ReadLine();
                            }

                            Console.Write("Enter the release date of the movie:");
                            string releaseD = Console.ReadLine();
                            DateTime releaseDate;
                            while (!DateTime.TryParse(releaseD, out releaseDate))
                            {
                                Console.WriteLine("The release date is invalid! It must be in format yyyy-mm-dd.");
                                Console.Write("Enter the release date of the movie:");
                                releaseD = Console.ReadLine();
                            }

                            Console.Write("Enter the description of the movie:");
                            string description = Console.ReadLine();

                            Console.Write("Enter the genre of the movie:");
                            string genre = Console.ReadLine();

                            if (movieService.addMovie(name, releaseDate, description, genre) == 0)
                            {
                                Console.WriteLine($"{name} added successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Something went wrong. {name} wasn't added.");
                            }
                        }
                        else if (input == "2")
                        {
                            Console.Write("Enter the id of the movie you want to delete:");
                            int movieID = int.Parse(Console.ReadLine());

                            if (movieService.deleteMovie(movieID) == 0)
                            {
                                Console.WriteLine($"Movie with id {movieID} deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Something went wrong. Movie with id {movieID} wasn't deleted.");
                            }
                        }
                        else if (input == "3")
                        {
                            Console.Write("Enter the id of the movie you want to update: ");
                            int movieID = int.Parse(Console.ReadLine());

                            Console.Write("Enter the new name of the movie: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter the new release date of the movie: ");
                            DateTime releaseDate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter the new description of the movie: ");
                            string description = Console.ReadLine();

                            Console.Write("Enter the new genre of the movie: ");
                            string genre = Console.ReadLine();

                            if (movieService.updateMovie(movieID, name, releaseDate, description, genre) == 0)
                            {
                                Console.WriteLine($"Movie with id {movieID} was updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Something went wrong. Movie with id {movieID} wasn't updated.");
                            }
                        }
                        else if (input == "4")
                        {
                            Console.Write(movieService.printMovies());

                        }
                        else if (input == "5")
                        {
                            Console.Write("Enter the id of the movie: ");
                            int movieID = int.Parse(Console.ReadLine());
                            Console.Write(movieService.getMovieInformation(movieID));
                        }
                        else if (input == "0")
                        {
                            break;
                        }
                        else if (input == "6")
                        {
                            Console.Write("Enter the year: ");
                            int year = int.Parse(Console.ReadLine());
                            Console.Write(movieService.filterMoviesByYear(year));
                        }
                        else if (input == "7")
                        {
                            Console.Write("Enter the genre: ");
                            string genre = Console.ReadLine() ;
                            Console.WriteLine(movieService.filterMoviesByGenre(genre));
                        }
                        else if (input == "8")
                        {
                            Console.Write("Enter the start date:");
                            DateTime startDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Enter the end date:");
                            DateTime endDate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine(movieService.filterMoviesByTimeInterval(startDate, endDate));
                        }
                        else if (input == "9")
                        {
                            Console.WriteLine(movieService.sortMoviesBasedOnCriteria("name"));
                        }
                        else if (input == "10")
                        {
                            Console.WriteLine(reviewService.bestRatedMovies());
                        }
                    }
                }
                else if (choice == "2")
                {
                    while (true)
                    {
                        personService.printMenu();
                        Console.Write("Enter an option: ");
                        string input = Console.ReadLine();

                        if (input == "1")
                        {
                            Console.Write("Enter the first name of the person: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Enter the last name of the person: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Enter the birthdate of the person (yyyy-mm-dd): ");
                            DateTime birthdate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter the email of the person: ");
                            string email = Console.ReadLine();

                            if (personService.addPerson(firstName, lastName, birthdate, email) == 0)
                            {
                                Console.WriteLine($"{firstName} {lastName} added successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Something went wrong. {firstName} {lastName} wasn't added.");
                            }
                        }
                        else if (input == "2")
                        {
                            Console.Write("Enter the id of the person you want to delete: ");
                            int personID = int.Parse(Console.ReadLine());

                            if (personService.deletePerson(personID) == 0)
                            {
                                Console.WriteLine($"Person with id {personID} deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Something went wrong. Person with id {personID} wasn't deleted.");
                            }
                        }
                        else if (input == "3")
                        {
                            Console.Write("Enter the id of the person you want to update: ");
                            int personID = int.Parse(Console.ReadLine());

                            Console.Write("Enter the new first name of the person: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Enter the new last name of the person: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Enter the new birthdate of the person (yyyy-mm-dd): ");
                            DateTime birthdate = DateTime.Parse(Console.ReadLine());

                            Console.Write("Enter the new email of the person: ");
                            string email = Console.ReadLine();

                            if (personService.updatePerson(personID, firstName, lastName, birthdate, email) == 0)
                            {
                                Console.WriteLine($"Person with id {personID} was updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Something went wrong. Person with id {personID} wasn't updated.");
                            }
                        }
                        else if (input == "4")
                        {
                            Console.WriteLine(personService.printPersons());
                        }
                        else if (input == "5")
                        {
                            Console.Write("Enter the id of the person: ");
                            int personID = int.Parse(Console.ReadLine());
                            Console.WriteLine(personService.getPersonInformation(personID));
                        }
                        else if (input == "0")
                        {
                            break;
                        }
                    }
                }
                else if (choice == "0")
                {
                    break;
                }
                else if (choice == "3")
                {
                    while (true)
                    {
                        reviewService.printMenu();
                        Console.Write("Enter an option: ");
                        string input = Console.ReadLine();

                        if (input == "1")
                        {
                            Console.Write("Enter the movie id for the review: ");
                            int movieID = int.Parse(Console.ReadLine());

                            Console.Write("Enter the rating: ");
                            int rating = int.Parse(Console.ReadLine());

                            Console.Write("Enter the comment for the review: ");
                            string comment = Console.ReadLine();

                            if (reviewService.addReview(movieID, rating, comment) == 0)
                            {
                                Console.WriteLine("Review added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add review.");
                            }
                        }
                        else if (input == "2")
                        {
                            Console.Write("Enter the review id to delete: ");
                            int reviewID = int.Parse(Console.ReadLine());

                            if (reviewService.deleteReview(reviewID) == 0)
                            {
                                Console.WriteLine("Review deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete review.");
                            }
                        }
                        else if (input == "3")
                        {
                            Console.Write("Enter the review ID to update: ");
                            int reviewID = int.Parse(Console.ReadLine());

                            Console.Write("Enter the new rating (1-10): ");
                            int rating = int.Parse(Console.ReadLine());

                            Console.Write("Enter the new comment: ");
                            string comment = Console.ReadLine();

                            if (reviewService.updateReview(reviewID, rating, comment) == 0)
                            {
                                Console.WriteLine("Review updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to update review.");
                            }
                        }
                        else if (input == "4")
                        {
                            Console.WriteLine(reviewService.printReviews());
                        }
                        else if (input == "5")
                        {
                            Console.Write("Enter the review id: ");
                            int reviewID = int.Parse(Console.ReadLine());
                            Console.WriteLine(reviewService.getReviewInformation(reviewID));
                        }
                        else if (input == "0")
                        {
                            break;
                        }
                        else if (input == "6")
                        {
                            Console.Write("Enter the movie id: ");
                            int movieID = int.Parse(Console.ReadLine());
                            Console.Write(reviewService.filterReviewByMovie(movieID));
                        }
                        else if (input == "7")
                        {
                            Console.Write("Enter the rating: ");
                            int rating = int.Parse(Console.ReadLine());
                            Console.Write(reviewService.filterReviewByRating(rating));
                        }
                        else if (input == "8")
                        {
                            Console.Write("Enter the movie ID: ");
                            int movieID = int.Parse(Console.ReadLine());
                            int avg = reviewService.averageRatingForMovie(movieID);
                            if (avg != -1)
                            {
                                Console.WriteLine($"The average rating for this movie is {avg}.");
                            }
                            else
                            {
                                Console.WriteLine("The movie has no reviews.");
                            }
                        }
                    }
                }
                else if (choice == "4") 
                {
                    while (true)
                    {
                        roleService.printMenu();
                        Console.Write("Enter an option: ");
                        string input = Console.ReadLine();

                        if (input == "1")
                        {
                            Console.Write("Enter the movie id for the role: ");
                            int movieID = int.Parse(Console.ReadLine());

                            Console.Write("Enter the person id for the role: ");
                            int personID = int.Parse(Console.ReadLine());

                            Console.Write("Enter the description for the role: ");
                            string name = Console.ReadLine();

                            if (roleService.addRole(movieID, personID, name) == 0)
                            {
                                Console.WriteLine("Role added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add role.");
                            }
                        }
                        else if (input == "2")
                        {
                            Console.Write("Enter the role id to delete: ");
                            int roleID = int.Parse(Console.ReadLine());

                            if (roleService.deleteRole(roleID) == 0)
                            {
                                Console.WriteLine("Role deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to delete role.");
                            }
                        }
                        else if (input == "3")
                        {
                            Console.Write("Enter the role ID to update: ");
                            int roleID = int.Parse(Console.ReadLine());

                            Console.Write("Enter the new movie ID: ");
                            int movieID = int.Parse(Console.ReadLine());

                            Console.Write("Enter the new person ID: ");
                            int personID = int.Parse(Console.ReadLine());

                            Console.Write("Enter the new name: ");
                            string name = Console.ReadLine();

                            if (roleService.updateRole(roleID, movieID, personID, name) == 0)
                            {
                                Console.WriteLine("Role updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to update role.");
                            }
                        }
                        else if (input == "4")
                        {
                            Console.WriteLine(roleService.printRoles());
                        }
                        else if (input == "5")
                        {
                            Console.Write("Enter the role id: ");
                            int roleID = int.Parse(Console.ReadLine());
                            Console.WriteLine(roleService.getRoleInformation(roleID));
                        }
                        else if (choice == "6")
                        {
                            Console.Write("Enter the year:");
                            int year = int.Parse(Console.ReadLine());
                            Console.WriteLine(movieService.filterMoviesByYear(year));
                        }
                        else if (choice == "7")
                        {
                            Console.Write("Enter the genre:");
                            string genre = Console.ReadLine();
                            Console.WriteLine(movieService.filterMoviesByGenre(genre));
                        }
                        else if (input == "0")
                        {
                            break;
                        }
                    }
                }
            }
            }
        }
}

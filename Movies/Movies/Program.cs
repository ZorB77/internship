using Movies.Persistance;
using Movies.Services;
using System;
using System.Data.SqlTypes;
using System.Linq;

namespace Movies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoviesDbContext db = new MoviesDbContext();
            Repository<Movie> movieRepository = new Repository<Movie>(db);
            Repository<Person> personRepository = new Repository<Person>(db);
            RoleRepository roleRepository = new RoleRepository(db);
            ReviewRepository reviewRepository = new ReviewRepository(db);
            Repository<Studio> studioRepository = new Repository<Studio>(db);
            AssociationRepository associationRepository = new AssociationRepository(db);


            MovieService movieService = new MovieService(movieRepository);
            PersonService personService = new PersonService(personRepository);
            RoleService roleService = new RoleService(roleRepository, movieRepository, personRepository);
            ReviewService reviewService = new ReviewService(reviewRepository, movieRepository);
            StudioService studioService = new StudioService(studioRepository);
            AssociationService associationService = new AssociationService(movieRepository, studioRepository, associationRepository);


            void ConsoleMenu()
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1: Movie");
                    Console.WriteLine("2: Person (Crew cast/Customer)");
                    Console.WriteLine("3: Review");
                    Console.WriteLine("4: Studio");
                    Console.WriteLine("x: Exit");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            movieMenu();
                            break;
                        case "2":
                            personMenu();
                            break;
                        case "3":
                            reviewMenu();
                            break;
                        case "4":
                            studioMenu();
                            break;
                        case "x":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }

            void movieMenu()
            {

                bool running = true;
                while (running)
                {
                    Console.WriteLine("Welcome to Movie menu, select an option:");
                    Console.WriteLine("1: Add a movie");
                    Console.WriteLine("2: See all movies");
                    Console.WriteLine("3: Update a specific movie"); 
                    Console.WriteLine("4: Delete a specific movie");
                    Console.WriteLine("5: See the average rating of a movie");
                    Console.WriteLine("6: See top 10 movies with the higher ratings");
                    Console.WriteLine("7: Sort all the movies alphabetically by name");
                    Console.WriteLine("8: Sort all the movies by year of release");
                    Console.WriteLine("9: Filter movies by year of release");
                    Console.WriteLine("10: Filter movies by genre");
                    Console.WriteLine("11: Filter movies by a specific date interval");
                    Console.WriteLine("x: Exit");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            try {
                                Console.WriteLine("enter an id: ");
                                var id = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter a name: ");
                                var name = Console.ReadLine();
                                Console.WriteLine("enter a year: ");
                                var year = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter a description: ");
                                var description = Console.ReadLine();
                                Console.WriteLine("enter a genre: ");
                                var genre = Console.ReadLine();
                                Console.WriteLine("enter the duration (in minutes): ");
                                var duration = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the budget of the movie: ");
                                var budget = SqlMoney.Parse(Console.ReadLine());
                                movieService.AddMovie(id, name, year, description, genre, duration, budget);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            
                            break;
                        case "2":
                            foreach (var movie in movieService.GetAll())
                            {
                                Console.WriteLine(movie.ToString());
                            }
                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("enter the id of the movie you want to update: ");
                                var id = int.Parse(Console.ReadLine());
                                if(movieService.CheckIfExists(id)) 
                                {
                                    Console.WriteLine($" You are about to update the movie \n {movieService.GetById(id).ToString()}");
                                    Console.WriteLine("enter the new name: ");
                                    var name = Console.ReadLine();
                                    Console.WriteLine("enter the new year: ");
                                    var year = int.Parse(Console.ReadLine());
                                    Console.WriteLine("enter the new description: ");
                                    var description = Console.ReadLine();
                                    Console.WriteLine("enter the new genre: ");
                                    var genre = Console.ReadLine();
                                    Console.WriteLine("enter the new duration (in minutes): ");
                                    var duration = int.Parse(Console.ReadLine());
                                    Console.WriteLine("enter the new budget of the movie: ");
                                    var budget = SqlMoney.Parse(Console.ReadLine());
                                    movieService.UpdateMovie(id, name, year, description, genre, duration, budget);
                                }
                                else { throw new Exception("Error: there is no movie with this id");  }
                                
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }

                            break;
                        case "4":
                            try {
                                Console.WriteLine("enter the id of the movie you want to delete: ");
                                var movieId = int.Parse(Console.ReadLine());
                                Console.WriteLine($" You are about to delete the movie \n {movieService.GetById(movieId).ToString()} \n proceed (y/n)?");
                                var resp = Console.ReadLine();
                                if (resp == "y")
                                {
                                    movieService.DeleteMovie(movieId);
                                }
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "5":
                            try {
                                Console.WriteLine("enter the id of the movie you want to see the average rating: ");
                                var movieId = int.Parse(Console.ReadLine());
                                if(reviewService.GetTheAverageRatingOfAMovie(movieId) == -1)
                                {
                                    Console.WriteLine($"There is no movie with this id ");
                                }
                                else
                                {
                                    Console.WriteLine($"the average rating of the movie {movieService.GetById(movieId).Name} is: " + reviewService.GetTheAverageRatingOfAMovie(movieId));
                                }
                            } catch (Exception ex) { Console.WriteLine(ex.Message ); }
                            
                            break;
                        case "6":
                            var n = 1;
                            foreach (var movie in reviewService.Top10MoviesWithHigherRating())
                            {
                                Console.WriteLine( $"{n++} {reviewService.GetTheAverageRatingOfAMovie(movie.MovieId)} {movie.ToString()}");
                            }
                            break;
                        case "7":
                            foreach (var movie in movieService.SortbyTitle())
                            {
                                Console.WriteLine(movie.ToString());
                            }
                            break;
                        case "8":
                            foreach (var movie in movieService.SortbyYear())
                            {
                                Console.WriteLine(movie.ToString());
                            }
                            break;
                        case "9":
                            try
                            {
                                Console.WriteLine("Enter the year:");
                                var year = int.Parse(Console.ReadLine());
                                if (!movieService.FilterMoviesByYear(year).Any())
                                {
                                    throw new Exception($"No movie in our database in the year {year}");
                                }
                                foreach (var movie in movieService.FilterMoviesByYear(year))
                                {
                                    Console.WriteLine(movie.ToString());
                                }

                            } catch (Exception ex) { Console.WriteLine( ex.Message ); }  
                            break;
                        case "10":
                            try
                            {
                                Console.WriteLine("Enter the genre:");
                                var genre = Console.ReadLine();
                                if (!movieService.FilterMoviesByGenre(genre).Any())
                                {
                                    throw new Exception($"No movie in our database with the genre {genre}");
                                }
                                foreach (var movie in movieService.FilterMoviesByGenre(genre))
                                {
                                    Console.WriteLine(movie.ToString());
                                }

                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "11":
                            try
                            {
                                Console.WriteLine("Enter the start date:");
                                var dateStart = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the stop date:");
                                var dateStop = DateTime.Parse(Console.ReadLine());
                                if (!movieService.FilterMoviesByDate(dateStart, dateStop).Any())
                                {
                                    throw new Exception($"No movie in our database between {dateStart:dd-MM-yyyy} and {dateStop:dd-MM-yyyy}");
                                }
                                foreach (var movie in movieService.FilterMoviesByDate(dateStart, dateStop))
                                {
                                    Console.WriteLine(movie.ToString());
                                }

                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "x":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }

            }

            void personMenu()
            {

                bool running = true;
                while (running)
                {
                    Console.WriteLine("Welcome to Person menu, select an option:");
                    Console.WriteLine("1: Add a person");
                    Console.WriteLine("2: See all persons");
                    Console.WriteLine("3: Update a specific person");
                    Console.WriteLine("4: Delete a specific person");
                    Console.WriteLine("5: Give a role to a person");
                    Console.WriteLine("6: See all the roles of a person");
                    Console.WriteLine("7: Filter people born in a specific date range ");
                    Console.WriteLine("8: Remove a role to a person");
                    Console.WriteLine("9: Update the role of a person");
                    Console.WriteLine("x: Exit");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            try
                            {
                                Console.WriteLine("enter an id: ");
                                var id = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the first name: ");
                                var firstname = Console.ReadLine();
                                Console.WriteLine("enter a the last name: ");
                                var lastname = Console.ReadLine();
                                Console.WriteLine("enter the date of birth: ");
                                var birthday = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("enter an email: ");
                                var email = Console.ReadLine();
                                personService.AddPerson(id, firstname, lastname, birthday, email);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "2":
                            foreach (var person in personService.GetAll())
                            {
                                Console.WriteLine(person.ToString());
                            }
                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("enter the id of the person you want to update: ");
                                var id = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter a new first name: ");
                                var firstname = Console.ReadLine();
                                Console.WriteLine("enter a new last name: ");
                                var lastname = Console.ReadLine();
                                Console.WriteLine("enter a new birtday: ");
                                var birthday = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("enter a new email: ");
                                var email = Console.ReadLine();

                                personService.UpdatePerson(id, firstname, lastname, birthday, email);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }

                            break;
                        case "4":
                            try
                            {
                                Console.WriteLine("enter the id of the person you want to delete: ");
                                var personID = int.Parse(Console.ReadLine());
                                Console.WriteLine($" You are about to delete the person \n {personService.GetById(personID).ToString()} \n proceed (y/n)?");
                                var resp = Console.ReadLine();
                                if (resp == "y")
                                {
                                    personService.DeletePerson(personID);
                                }
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "5":
                            try {
                                Console.WriteLine("enter the id of the role: ");
                                var roleId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the id of the person you want to give a role: ");
                                var personId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the id of the movie: ");
                                var movieId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the role: ");
                                var name = Console.ReadLine();
                                Console.WriteLine("enter the description of the role: ");
                                var description = Console.ReadLine();
                                roleService.AddRole(roleId, movieId, personId, name, description);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "6":
                            try {
                                Console.WriteLine("enter the id of the person you want to see the roles: ");
                                var personId = int.Parse(Console.ReadLine());
                                foreach (var role in roleService.GetRolesOfAPerson(personId))
                                {
                                    Console.WriteLine(role.ToString());
                                }
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "7":
                            try
                            {
                                Console.WriteLine("Enter the start date:");
                                var dateStart = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the stop date:");
                                var dateStop = DateTime.Parse(Console.ReadLine());
                                if (!personService.FilterPersonByDate(dateStart, dateStop).Any())
                                {
                                    throw new Exception($"No person in our database born between {dateStart:dd-MM-yyyy} and {dateStop:dd-MM-yyyy}");
                                }
                                foreach (var person in personService.FilterPersonByDate(dateStart, dateStop))
                                {
                                    Console.WriteLine(person.ToString());
                                }

                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "8":
                            try {
                                Console.WriteLine("enter the id of the person you want to delete his/her role: ");
                                var personId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the id of the movie that person has a role: ");
                                var movieId = int.Parse(Console.ReadLine());
                                roleService.DeleteRole(roleService.GetAll().Find(r => r.Person.PersonId == personId && r.Movie.MovieId == movieId).RoleId);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "9":
                            try {
                                Console.WriteLine("enter the id of the role you want to update: ");
                                var roleId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the new id of the person you want to give the role: ");
                                var personId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the new id of the movie: ");
                                var movieId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the role: ");
                                var name = Console.ReadLine();
                                Console.WriteLine("enter the new description of the role: ");
                                var description = Console.ReadLine();
                                roleService.UpdateRole(roleId, movieId, personId, name, description);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "x":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }

            }

            void reviewMenu()
            {

                bool running = true;
                while (running)
                {
                    Console.WriteLine("Welcome to Review menu, select an option:");
                    Console.WriteLine("1: Add a review to a movie");
                    Console.WriteLine("2: See all reviews of a movie");
                    Console.WriteLine("3: Update a reviews of a movie");
                    Console.WriteLine("4: Delete a reviews of a movie");

                    Console.WriteLine("x: Exit");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            try
                            {
                                Console.WriteLine("enter a review id: ");
                                var reviewId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter a rating between [1, 10], it can be a float: ");
                                var rating = float.Parse(Console.ReadLine());
                                Console.WriteLine("enter a comment: ");
                                var comment = Console.ReadLine();
                                Console.WriteLine("enter the movie id you want to give this review: ");
                                var movieId = int.Parse(Console.ReadLine());
                                reviewService.AddReview(reviewId, rating, comment, movieId);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "2":
                            try
                            {
                                Console.WriteLine("enter the movie id: ");
                                var movieID = int.Parse(Console.ReadLine());
                                foreach (var review in reviewService.GetAll().Where(r => r.Movie.MovieId == movieID))
                            {
                                    Console.WriteLine(review.ToString());
                                }
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            
                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("enter the id of the review you want to update: ");
                                var reviewId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter a new rating between [1, 10], it can be a float: ");
                                var rating = float.Parse(Console.ReadLine());
                                Console.WriteLine("enter a new comment: ");
                                var comment = Console.ReadLine();
                                Console.WriteLine("enter the new movie id you want to give this review: ");
                                var movieId = int.Parse(Console.ReadLine());
                                reviewService.UpdateReview(reviewId, rating, comment, movieId);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "4":
                            try
                            {
                                Console.WriteLine("enter the id of the review you want to delete: ");
                                var reviewId = int.Parse(Console.ReadLine());
                                Console.WriteLine($" You are about to delete the review \n {reviewService.GetByIdReview(reviewId).ToString()} \n proceed (y/n)?");
                                var resp = Console.ReadLine();
                                if (resp == "y")
                                {
                                    reviewService.DeleteReview(reviewId);
                                }


                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "x":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }

            }

            void studioMenu()
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("Welcome to Studio menu, select an option:");
                    Console.WriteLine("1: Add a studio");
                    Console.WriteLine("2: See all the studios");
                    Console.WriteLine("3: Asign a movie to a studio");
                    Console.WriteLine("4: See all movies of a movie");
                    Console.WriteLine("5: See all studios of a studio");
                    Console.WriteLine("6: See all studios and movies");
                    Console.WriteLine("x: Exit");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            try
                            {
                                Console.WriteLine("enter an id for the studio: ");
                                var studioId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter a name for the studio: ");
                                var name = Console.ReadLine();
                                Console.WriteLine("enter the year: ");
                                var year = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the studio location city: ");
                                var location = Console.ReadLine();
                                studioService.AddStudio(studioId, name, year, location);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "2":
                            try
                            {
                                if (studioService.GetStudios().Any())
                                {
                                    foreach (var studio in studioService.GetStudios())
                                    {
                                        Console.WriteLine(studio.ToString());
                                    }
                                } else
                                {
                                    throw new Exception("No studios in our database!");
                                }
                                
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }

                            break;
                        case "3":
                            try
                            {
                                Console.WriteLine("enter the id of the association: ");
                                var associationId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the id of the movie ");
                                var movieId = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the id of the studio ");
                                var studioId = int.Parse(Console.ReadLine());
                                associationService.AddAssociation(associationId, movieId, studioId);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "4":
                            try
                            {
                                Console.WriteLine("Enter the movie id:");
                                var movieId = int.Parse (Console.ReadLine());

                                if(movieService.CheckIfExists(movieId)) {
                                    if (associationService.GetAllAssociations().Where(a => a.Movie.MovieId == movieId).Any())
                                    {
                                        foreach (var association in associationService.GetAllAssociations().Where(a => a.Movie.MovieId == movieId))
                                        {
                                            Console.WriteLine(association.ToString());
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception($"No association with the movie {movieService.GetById(movieId).Name} in our database!");
                                    }
                                }
                                else { throw new Exception($"there is no movie with the id {movieId}"); }

                                

                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "5":
                            try
                            {
                                Console.WriteLine("Enter the studio id:");
                                var studioId = int.Parse(Console.ReadLine());

                                if (studioService.GetById(studioId) != null)
                                {

                                    if (associationService.GetAllAssociations().Where(a => a.Studio.StudioId == studioId).Any())
                                    {
                                        foreach (var association in associationService.GetAllAssociations().Where(a => a.Studio.StudioId == studioId))
                                        {
                                            Console.WriteLine(association.ToString());
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception($"No association with the studio {studioService.GetById(studioId).Name} in our database!");
                                    }
                                }
                                else { throw new Exception($"there is no studio with the id {studioId}"); }

                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;

                        case "6":
                            try
                            {
                                if (associationService.GetAllAssociations().Any())
                                {
                                    foreach (var association in associationService.GetAllAssociations())
                                    {
                                        Console.WriteLine(association.ToString());
                                    }
                                }
                                else
                                {
                                    throw new Exception($"No association found in our database!");
                                }
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                            break;
                        case "x":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
            }
            ConsoleMenu();
        }
    }
}

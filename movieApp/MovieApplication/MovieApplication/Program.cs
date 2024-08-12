using Microsoft.Extensions.DependencyInjection;
using MovieApp.Models;
using MovieApp.Services;
using MovieApplication.Services;
using System;
using System.Transactions;

namespace MovieApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                    .AddSingleton<MovieContext>()
                    .AddSingleton<MovieService>()
                    .AddSingleton<PersonService>()
                    .AddSingleton<ReviewService>()
                    .AddSingleton<RoleService>()
                    .BuildServiceProvider();

            var movieService = serviceProvider.GetService<MovieService>();
            var personService = serviceProvider.GetService<PersonService>();
            var reviewService = serviceProvider.GetService<ReviewService>();
            var roleService = serviceProvider.GetService<RoleService>();

            while (true)
            {
                Console.WriteLine("\n1 - Movie options");
                Console.WriteLine("2 - Person options");
                Console.WriteLine("3 - Review options");
                Console.WriteLine("4 - Role options");
                Console.WriteLine("5 - Exit");

                Console.WriteLine("Select option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    //case 1
                    case "1":
                        movieService.MovieOptions();
                        Console.WriteLine("Select option: ");
                        string input1 = Console.ReadLine();
                        switch (input1)
                        {
                            //SUBCASE 1 - AddMovie
                            case "1":
                                Console.WriteLine("\nEnter movie title: ");
                                string title = Console.ReadLine();
                                if (title == null)
                                {
                                    Console.WriteLine("It's mandatory to add the title in order to proceed!");
                                    title = Console.ReadLine();
                                }

                                Console.WriteLine("Enter movie release date: ");
                                string releaseDate = Console.ReadLine();
                                DateTime ReleaseDate;
                                if (!DateTime.TryParse(releaseDate, out ReleaseDate))
                                {
                                    Console.WriteLine("Invalid release date! Must be yyyy-MM-dd.");
                                    Console.WriteLine("Enter movie year: ");
                                    releaseDate = Console.ReadLine();
                                }

                                Console.WriteLine("Enter movie description: ");
                                string description = Console.ReadLine();
                                if (description == null)
                                {
                                    Console.WriteLine("It's mandatory to add the description in order to proceed!");
                                    description = Console.ReadLine();
                                }

                                Console.WriteLine("Enter movie genre: ");
                                string genre = Console.ReadLine();
                                if (genre == null)
                                {
                                    Console.WriteLine("It's mandatory to add the genre in order to proceed!");
                                    genre = Console.ReadLine();
                                }

                                bool result = movieService.AddMovie(title, ReleaseDate, description, genre);
                                if (result)
                                {
                                    Console.WriteLine($"Movie {title} added succesfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 2 - GetMoviesList
                            case "2":
                                List<Movie> allMovies = movieService.GetAllMovies();
                                Console.WriteLine("\nAll the movies from db: ");
                                foreach (var movies in allMovies)
                                {
                                    Console.WriteLine($"{movies.Title}");
                                }
                                break;

                            //SUBCASE 3 - GetMovieById
                            case "3":
                                Console.WriteLine("\nEnter the movie id: ");
                                int movieId = int.Parse(Console.ReadLine());

                                Movie movie = movieService.GetMovieById(movieId);

                                if (movieId != null)
                                {
                                    Console.WriteLine($"Movie with id {movieId}: {movie.Title}");
                                }
                                else
                                {
                                    Console.WriteLine("Movie not found!");
                                }

                                break;

                            //SUBCASE 4 - DeleteMovie
                            case "4":
                                Console.WriteLine("\nEnter movie id to delete: ");
                                movieId = int.Parse(Console.ReadLine());

                                result = movieService.DeleteMovie(movieId);
                                if (result)
                                {
                                    Console.WriteLine($"Movie {movieId} was succesfully deleted!");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 5 - UpdateMovie
                            case "5":
                                Console.WriteLine("\nEnter movie id to update: ");
                                movieId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new title: ");
                                title = Console.ReadLine();

                                Console.WriteLine("Enter the new year: ");
                                ReleaseDate = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new description: ");
                                description = Console.ReadLine();

                                Console.WriteLine("Enter the new genre: ");
                                genre = Console.ReadLine();

                                result = movieService.UpdateMovie(movieId, title, ReleaseDate, description, genre);
                                if (result)
                                {
                                    Console.WriteLine($"Movie {title} was succesfully updated!");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 6 - FilterMoviesByGenre
                            case "6":
                                Console.WriteLine("\nEnter the genre: ");
                                genre = Console.ReadLine();
                                Console.WriteLine($"{genre} movies: " + movieService.FilterMoviesByGenre(genre));
                                break;

                            //SUBCASE 7 - FilterMoviesByYear
                            case "7":
                                Console.WriteLine("\nEnter the year: ");
                                int year = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Movies from {year}: " + movieService.FilterMoviesByYear(year));
                                break;

                            //SUBCASE 8 - FilterMoviesByDateInterval
                            case "8":
                                Console.WriteLine("\nEnter the 1st year: ");
                                DateTime firstYear = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the 2nd year: ");
                                DateTime secondYear = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine($"Movies between {firstYear.ToShortDateString()} and {secondYear.ToShortDateString}: " + movieService.FilterMoviesByDateInterval(firstYear, secondYear));
                                break;

                            //SUBCASE 9
                            case "9":
                                break;
                        }
                        break;

                    //CASE 2
                    case "2":
                        personService.PersonOptions();
                        Console.WriteLine("Select option: ");
                        string input2 = Console.ReadLine();
                        switch (input2)
                        {
                            //SUBCASE 1 - AddPerson
                            case "1":
                                Console.WriteLine("\nEnter the first name: ");
                                string firstName = Console.ReadLine();
                                if (firstName == null)
                                {
                                    Console.WriteLine("It's mandatory to add the first name in order to proceed!");
                                    firstName = Console.ReadLine();
                                }

                                Console.WriteLine("Enter the last name: ");
                                string lastName = Console.ReadLine();
                                if (lastName == null)
                                {
                                    Console.WriteLine("It's mandatory to add the last name in order to proceed!");
                                    lastName = Console.ReadLine();
                                }

                                Console.WriteLine("Enter the birthdate: ");
                                DateTime birthdate = DateTime.Parse(Console.ReadLine());
                                if (birthdate == null)
                                {
                                    Console.WriteLine("It's mandatory to add the birthdate in order to proceed!");
                                    birthdate = DateTime.Parse(Console.ReadLine());
                                }

                                bool result = personService.AddPerson(firstName, lastName, birthdate);
                                if (result)
                                {
                                    Console.WriteLine($"{firstName} {lastName} added succesfully.");
                                }
                                else
                                {
                                    Console.WriteLine($"{firstName} {lastName} wasn't added. Please try again!");
                                }
                                break;

                            //SUBCASE 2 - GetPersonsList
                            case "2":
                                List<Person> allPersons = personService.GetAllPersons();
                                Console.WriteLine("\nAll the persons from db: ");
                                foreach (var persons in allPersons)
                                {
                                    Console.WriteLine($"{persons.FirstName} {persons.LastName}");
                                }
                                break;

                            //SUBCASE 3 - GetPersonById
                            case "3":
                                Console.WriteLine("\nEnter the person id: ");
                                int personId = int.Parse(Console.ReadLine());
                                Person person = personService.GetPersonById(personId);

                                if (personId != null)
                                {
                                    Console.WriteLine($"Person with id {personId}: {person.FirstName} {person.LastName}");
                                }
                                else
                                {
                                    Console.WriteLine("Person not found!");
                                }
                                break;

                            //SUBCASE 4 - DeletePerson
                            case "4":
                                Console.WriteLine("\nEnter person id to delete: ");
                                personId = int.Parse(Console.ReadLine());

                                result = personService.DeletePerson(personId);
                                if (result)
                                {
                                    Console.WriteLine($"Person {personId} was succesfully deleted!");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 5 - UpdatePerson 
                            case "5":
                                Console.WriteLine("\nEnter person id to update: ");
                                personId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new first name: ");
                                firstName = Console.ReadLine();

                                Console.WriteLine("Enter the new last name: ");
                                lastName = Console.ReadLine();

                                Console.WriteLine("Enter the new birthday: ");
                                birthdate = DateTime.Parse(Console.ReadLine());

                                result = personService.UpdatePerson(personId, firstName, lastName, birthdate);
                                if (result)
                                {
                                    Console.WriteLine($"Person {personId} was succesfully updated!");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 6
                            case "6":
                                break;
                        }
                        break;

                    //CASE 3
                    case "3":
                        reviewService.ReviewOptions();
                        Console.WriteLine("Select option: ");
                        string input3 = Console.ReadLine();
                        switch (input3)
                        {
                            //SUBCASE 1 - AddReview
                            case "1":
                                Console.WriteLine("\nEnter movie id for review: ");
                                int movieId = int.Parse(Console.ReadLine());
                                while (movieId == null)
                                {
                                    Console.WriteLine("It's mandatory to add the movieId in order to proceed!");
                                    movieId = int.Parse(Console.ReadLine());
                                }

                                Console.WriteLine("Enter the rating: ");
                                double rating = double.Parse(Console.ReadLine());
                                if (rating == null)
                                {
                                    Console.WriteLine("It's mandatory to add the rating in order to proceed!");
                                    rating = double.Parse(Console.ReadLine());
                                }

                                Console.WriteLine("Enter comment: ");
                                string comment = Console.ReadLine();
                                if (comment == null)
                                {
                                    Console.WriteLine("It's mandatory to add a comment in order to proceed!");
                                    comment = Console.ReadLine();
                                }

                                bool result = reviewService.AddReview(movieId, rating, comment);
                                if (result)
                                {
                                    Console.WriteLine($"Review for {movieId} added succesfully");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 2 - GetReviewsList
                            case "2":
                                List<Review> allReviews = reviewService.GetAllReviews();
                                Console.WriteLine("\nAll the reviews from db: ");
                                foreach (var reviews in allReviews)
                                {
                                    Console.WriteLine($"Review for movie id {reviews.MovieId}: {reviews.Comment}");

                                }
                                break;

                            //SUBCASE 3 - GerReviewById
                            case "3":
                                Console.WriteLine("\nEnter the review id: ");
                                int reviewId = int.Parse(Console.ReadLine());
                                Review review = reviewService.GetReviewById(reviewId);

                                if(review != null)
                                {
                                    Console.WriteLine($"Review with id {reviewId}: {review.Rating}, {review.Comment}");
                                }
                                else
                                {
                                    Console.WriteLine("Review not found!\n");
                                }
                                break;

                            //SUBCASE 4 - DeleteReview
                            case "4":
                                Console.WriteLine("\nEnter review id to delete: ");
                                reviewId = int.Parse(Console.ReadLine());

                                result = reviewService.DeleteReview(reviewId);
                                if (result)
                                {
                                    Console.WriteLine($"Movie {reviewId} was succesfully deleted!");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 5 - UpdateReview
                            case "5":
                                Console.WriteLine("\nEnter review id to update: ");
                                reviewId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new rating: ");
                                rating = double.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new comment: ");
                                comment = Console.ReadLine();

                                result = reviewService.UpdateReview(reviewId, rating, comment);
                                if (result)
                                {
                                    Console.WriteLine($"Review {reviewId} was succesfully updated!");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 6 - AverageRatingForGivenMovie
                            case "6":
                                Console.WriteLine("\nEnter the movie id: ");
                                movieId = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Average rating for movie {movieId} is: " + reviewService.AverageRatingForGivenMovie(movieId));
                                break;

                            //SUBCASE 7 - Top10Movies
                            case "7":
                                List<Movie> topMovies = reviewService.Top10Movies();
                                foreach (var movie in topMovies)
                                {
                                    Console.WriteLine($"\nTitle: {movie.Title}, Release date: {movie.ReleaseDate.ToShortDateString()}, Genre: {movie.Genre}");
                                }
                                break;

                            //SUBCASE 8 - FilterReviewbyRating
                            case "8":
                                Console.WriteLine("\nEnter the rating: ");
                                rating = int.Parse(Console.ReadLine());
                                Console.WriteLine($"Movies with the rating {rating}: " + reviewService.FilterReviewByRating(rating) + "");
                                break;

                            //SUBCASE 9
                            case "9":
                                break;
                        }
                        break;

                    //CASE 4
                    case "4":
                        roleService.RoleOptions();
                        Console.WriteLine("Select option: ");
                        string input4 = Console.ReadLine();
                        switch (input4)
                        {
                            //SUBCASE 1 - AddRole
                            case "1":
                                Console.WriteLine("\nEnter the movie id: ");
                                int movieId = int.Parse(Console.ReadLine());
                                if (movieId == null)
                                {
                                    Console.WriteLine("It's mandatory to add the movie id in order to proceed!");
                                    movieId = int.Parse(Console.ReadLine());
                                }

                                Console.WriteLine("Enter the person id: ");
                                int personId = int.Parse(Console.ReadLine());
                                if (personId == null)
                                {
                                    Console.WriteLine("It's mandatory to add the persons id in order to proceed!");
                                    personId = int.Parse(Console.ReadLine());
                                }

                                Console.WriteLine("Enter the name: ");
                                string name = Console.ReadLine();
                                if (name == null)
                                {
                                    Console.WriteLine("It's mandatory to add the name in order to proceed!");
                                    name = Console.ReadLine();
                                }

                                bool result = roleService.AddRole(movieId, personId, name);
                                if (result)
                                {
                                    Console.WriteLine($"{name} added succesfully.");
                                }
                                else
                                {
                                    Console.WriteLine($"{name} wasn't added. Please try again!");
                                }
                                break;

                            //SUBCASE 2 - GetRolesList
                            case "2":
                                List<Role> allRoles = roleService.GetAllRoles();
                                Console.WriteLine("\nAll the roles from db: ");
                                foreach (var roles in allRoles)
                                {
                                    Console.WriteLine($"{roles.Name}");

                                }
                                break;

                            //SUBCASE 3 - GetRoleById
                            case "3":
                                Console.WriteLine("\nEnter the role id: ");
                                int roleId = int.Parse(Console.ReadLine());
                                Role role = roleService.GetRoleById(roleId);

                                if (roleId != null)
                                {
                                    Console.WriteLine($"Role with id {roleId}: {role.Name}");
                                }
                                else
                                {
                                    Console.WriteLine("Role not found!\n");
                                }
                                break;

                            //SUBCASE 4 - DeleteRole
                            case "4":
                                Console.WriteLine("\nEnter role id to delete: ");
                                roleId = int.Parse(Console.ReadLine());

                                result = roleService.DeleteRole(roleId);
                                if (result)
                                {
                                    Console.WriteLine($"Role {roleId} was succesfully deleted!");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 5 - UpdateRole 
                            case "5":
                                Console.WriteLine("\nEnter role id to update: ");
                                roleId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new movie id: ");
                                movieId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new person id: ");
                                personId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the new name: ");
                                name = Console.ReadLine();

                                result = roleService.UpdateRole(roleId, movieId, personId, name);
                                if (result)
                                {
                                    Console.WriteLine($"Role {roleId} was succesfully updated!");
                                }
                                else
                                {
                                    Console.WriteLine("Something went wrong. Please try again later!");
                                }
                                break;

                            //SUBCASE 6
                            case "6":
                                break;
                        }
                        break;

                    //CASE 5
                    case "5":
                        return;

                    default:
                        break;
                }
            }
        }
    }
}

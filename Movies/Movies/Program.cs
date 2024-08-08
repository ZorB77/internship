using Microsoft.Win32;
using Movies.Services;
using System;
using System.Collections.Generic;

namespace Movies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoviesDbContext db = new MoviesDbContext();
            Repository<Movie> movieRepository = new Repository<Movie>(db);
            Repository<Person> personRepository = new Repository<Person>(db);
            Repository<Role> roleRepository = new Repository<Role>(db);

            Repository<Review> reviewRepository = new Repository<Review>(db);


            MovieService movieService = new MovieService(movieRepository);
            PersonService personService = new PersonService(personRepository);
            RoleService roleService = new RoleService(roleRepository, movieRepository, personRepository);
            ReviewService reviewService = new ReviewService(reviewRepository);



            void ConsoleMenu()
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1: Movie");
                    Console.WriteLine("2: Person (Crew cast/Customer)");
                    Console.WriteLine("3: Review");
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
                    Console.WriteLine("5: See the average rating to a movie");
                    Console.WriteLine("6: See top 10 movies with the higher ratings");
                    Console.WriteLine("7: Sort all the movies alphabetically by name");
                    Console.WriteLine("8: Sort all the movies by year of release");
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
                                movieService.AddMovie(id, name, year, description, genre);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
                            
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
                                Console.WriteLine($" You are about to update the movie \n {movieService.GetById(id).ToString()}");
                                Console.WriteLine("enter the new name: ");
                                var name = Console.ReadLine();
                                Console.WriteLine("enter the new year: ");
                                var year = int.Parse(Console.ReadLine());
                                Console.WriteLine("enter the new description: ");
                                var description = Console.ReadLine();
                                Console.WriteLine("enter the new genre: ");
                                var genre = Console.ReadLine();
                                movieService.UpdateMovie(id, name, year, description, genre);
                            }
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                            break;
                        case "4":
                            Console.WriteLine("enter the id of the movie you want to delete: ");
                            var movieId = int.Parse(Console.ReadLine());
                            Console.WriteLine($" You are about to delete the movie \n {movieService.GetById(movieId).ToString()} \n proceed (y/n)?");
                            var resp = Console.ReadLine();
                            if (resp == "y")
                            {
                                movieService.DeleteMovie(movieId);
                            }
                            break;
                        case "5":
                            
                            break;
                        case "6":
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
                    Console.WriteLine("7: Remove a role to a person");
                    Console.WriteLine("8: Update the role of a person");

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
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

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
                            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

                            break;
                        case "4":
                            Console.WriteLine("enter the id of the person you want to delete: ");
                            var personID = int.Parse(Console.ReadLine());
                            Console.WriteLine($" You are about to delete the person \n {personService.GetById(personID).ToString()} \n proceed (y/n)?");
                            var resp = Console.ReadLine();
                            if (resp == "y")
                            {
                                personService.DeletePerson(personID);
                            }
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
                            break;
                        case "2":
                            break;
                        case "4":
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

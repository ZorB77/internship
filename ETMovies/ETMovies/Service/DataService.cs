using ETMovies.DatabaseContext;
using ETMovies.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Service
{
    internal class DataService
    {
        public MyDbContext Context;

        public DataService(MyDbContext context)
        {
            Context = context;
        }

        #region MoviesCRUD

        // Add a movie
        public void AddMovie(Movie movie)
        {

            Context.Movies.Add(movie);
            Context.SaveChanges();

        }

        // Select * movies
        public List<Movie> GetMovies()
        {
            return Context.Movies.AsNoTracking().ToList();
        }

        public Movie GetMovieByID(int id)
        {
            var movie = Context.Movies.AsNoTracking().FirstOrDefault(m => m.MovieID == id);
            return movie;
        }

        // Update a movie

        public void UpdateMovie(int index, string title, string description, int year, string genre)
        {
            var movieToUpdate = Context.Movies.FirstOrDefault(m => m.MovieID == index);
            if (movieToUpdate != null)
            {
                movieToUpdate.Title = title;
                movieToUpdate.Description = description;
                movieToUpdate.Year = year;
                movieToUpdate.Genre = genre;
                Context.SaveChanges();

            }
        }

        // Delete a movie

        public void DeleteMovie(int index)
        {
            var movieToDelete = Context.Movies.First(m => m.MovieID == index);
            if (movieToDelete != null)
            {
                Context.Movies.Remove(movieToDelete);
                Context.SaveChanges();
            }

        }

        // Delete a movie by title

        public void DeleteMovieByTitle(string title)
        {
            var movieToDelete = Context.Movies.First(m => m.Title == title);
            if (movieToDelete != null)
            {

                Context.Movies.Remove(movieToDelete);
                Context.SaveChanges();
            }
        }

        #endregion

        #region PersonCRUD

        // Add a person
        public void AddPerson(Person person)
        {

            Context.Persons.Add(person);
            Context.SaveChanges();

        }

        // Select * persons
        public List<Person> GetPersons()
        {
            return Context.Persons.AsNoTracking().ToList();
        }

        // Update a person

        public void UpdatePerson(int index, string firstName, string lastName, DateOnly birthday, string mail)
        {
            var personToUpdate = Context.Persons.FirstOrDefault(m => m.PersonID == index);
            if (personToUpdate != null)
            {
                personToUpdate.FirstName = firstName;
                personToUpdate.LastName = lastName;
                personToUpdate.Birthdate = birthday;
                personToUpdate.email = mail;
                Context.SaveChanges();
            }
        }

        // Delete a person

        public void DeletePerson(int index)
        {
            var personToDelete = Context.Persons.FirstOrDefault(m => m.PersonID == index);
            if (personToDelete != null)
            {
                Context.Persons.Remove(personToDelete);
                Context.SaveChanges();
            }

        }
        #endregion

        #region RolesCRUD

        // Add a role
        public void AddRole(string name, int movieID, int personID)
        {
            if (movieID != null && personID != null)
            {
                var movie = Context.Movies.FirstOrDefault(m => m.MovieID == movieID);
                var person = Context.Persons.FirstOrDefault(p => p.PersonID == personID);
                Role role = new Role(movie, person, name);
                Context.Roles.Add(role);
                Context.SaveChanges();
            }


        }

        // Select * roles
        public List<Role> GetRoles()
        {
                        return Context.Roles.AsNoTracking().Include(r => r.Person).AsEnumerable().ToList();

        }

        // Update a role

        public void UpdateRole(int index, Movie movie, Person person, string name)
        {
            var roleToUpdate = Context.Roles.FirstOrDefault(m => m.RoleID == index);
            if (roleToUpdate != null)
            {
                roleToUpdate.Movie = movie;
                roleToUpdate.Person = person;
                roleToUpdate.Name = name;
                Context.SaveChanges();
            }
        }

        // Delete a role

        public void DeleteRole(int index)
        {
            var roleToDelete = Context.Roles.FirstOrDefault(m => m.RoleID == index);
            if (roleToDelete != null)
            {
                Context.Roles.Remove(roleToDelete);
                Context.SaveChanges();
            }

        }
        #endregion

        #region ReviewsCRUD

        // Add a review
        public void AddReview(Review review, int movieID)
        {
            if (movieID != null)
            {


                var movie = Context.Movies.FirstOrDefault(m => m.MovieID == movieID);
                movie.Review.Add(review);
                Context.SaveChanges();

            }

        }

        // Select * reviews
        public List<Movie> GetReviews()
        {
            return Context.Movies.Include(m => m.Review).AsNoTracking().ToList();
        }

        // Update a review

        public void UpdateReview(int index, int rating, string comment)
        {
            var reviewToUpdate = Context.Reviews.FirstOrDefault(m => m.ReviewId == index);
            if (reviewToUpdate != null)
            {
                reviewToUpdate.Rating = rating;
                reviewToUpdate.Comment = comment;
                Context.SaveChanges();
            }
        }

        // Delete a review

        public void DeleteReview(int index)
        {
            var reviewToDelete = Context.Reviews.FirstOrDefault(m => m.ReviewId == index);
            if (reviewToDelete != null)
            {
                Context.Reviews.Remove(reviewToDelete);
                Context.SaveChanges();
            }

        }
        #endregion

        #region requirements

        public List<Movie> GetMoviesByDateRange(int startYear, int endYear)
        {
            return Context.Movies.AsNoTracking().Where(m => m.Year >= startYear && m.Year <= endYear).ToList();

        }

        public List<Movie> SortMoviesByNameAndGenre()
        {
            return Context.Movies.OrderBy(m => m.Title).ThenBy(m => m.Genre).ToList();
        }

        public List<Movie> TopTenMoviesByRating()
        {
            return Context.Movies.Include(m => m.Review).AsEnumerable().OrderByDescending(t => t.GetAverageRating()).Take(10).ToList();
        }

        public double GetAverageRating(int movieID)
        {
            var movie = Context.Movies.Include(r => r.Review).FirstOrDefault(m => m.MovieID == movieID);
            if (movie != null)
            {
                return movie.GetAverageRating();
            }
            return 0.0;
        }

        public List<string> FilterActorsByRole(string role) {

            return Context.Roles.AsNoTracking().Where(r => r.Name == role).Select(r => r.Person.FirstName + " " + r.Person.LastName).AsEnumerable().ToList();

        }

        public List<Person> FilterPersonsByAge(int minAge, int maxAge) {

            DateTime currentDate = DateTime.Today;

            return Context.Persons.Where(r => (currentDate.Year - r.Birthdate.Year) >= minAge && (currentDate.Year - r.Birthdate.Year <= maxAge)).AsEnumerable().ToList();
        }

        #endregion
    }
}

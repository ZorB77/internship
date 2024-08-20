using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWebAPI.Models
{
    public class RoleTests
    {
        [Fact]
        public void ShouldCreateRole()
        {
            var movie = new Movie { ID = 1, Name = "Interstellar", Description = "Space travelling.", Genre = "Romance", ReleaseDate = new DateTime(2014, 8, 18) };
            var person = new Person { ID = 1, FirstName = "Anca", LastName = "Nistor", City = "Cluj-Napoca", Birthdate = new DateTime(2002, 8, 5), Phone = "0736058562" };

            var role = new Role { ID = 1, Name = "Actor", Description = "Description.", Salary = 50, Movie = movie, Person = person };
            var role2 = new Role { ID = 1, Name = "Actor", Description = "Description.", Salary = 5000, Movie = movie, Person = person };

            var validationResults = new List<ValidationResult>();

            var validationContext = new ValidationContext(role);
            var isValid = Validator.TryValidateObject(role, validationContext, validationResults, validateAllProperties: true);

            var validationContext2 = new ValidationContext(role2);
            var isValid2 = Validator.TryValidateObject(role2, validationContext2, validationResults, validateAllProperties: true);

            Assert.False(isValid);
            Assert.True(isValid2);
            Assert.IsType<Role>(role2);
            Assert.Equal("Actor", role2.Name);
        }
    }
}

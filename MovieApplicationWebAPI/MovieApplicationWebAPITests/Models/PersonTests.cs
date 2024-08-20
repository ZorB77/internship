using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWebAPI.Models
{
    public class PersonTests
    {
        [Fact]
        public void ShouldCreatePerson()
        {
            var person = new Person { ID = 1, FirstName = "Anca", LastName = "Nistor", City = "Cluj-Napoca", Birthdate = new DateTime(2002, 8, 5), Phone = "0736058562" };
            Assert.NotNull(person);
            Assert.IsType<Person>(person);
            Assert.Equal("Anca", person.FirstName);
        }
    }
}

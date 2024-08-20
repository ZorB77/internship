using Moq;
using MovieWebAPI.Persistance;

namespace MovieWebAPI.Mocks
{
    internal class MockPersonRepsitory
    {
        public static Mock<IRepository<Person>> GetMock()
        {
            var mock = new Mock<IRepository<Person>>();

            var people = new List<Person>()
            {
                new Person
                {
                    PersonId = 1,
                    FirstName = "Test",
                    LastName = "Test",
                    Birthdate = DateTime.Now,
                    Email = "test@test.com"
                }
            };

            mock.Setup(p => p.GetAllAsync()).ReturnsAsync(people);

            mock.Setup(p => p.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => people.FirstOrDefault(p => p.PersonId == id));
            mock.Setup(p => p.AddAsync(It.IsAny<Person>()))
                .Callback<Person>(p => people.Add(p))
                .Returns(Task.CompletedTask);
            mock.Setup(p => p.UpdateAsync(It.IsAny<Person>()))
                .Callback<Person>(person =>
                {
                    var existingPerson = people.FirstOrDefault(p => p.PersonId == person.PersonId);
                    if (existingPerson != null)
                    {
                        people.Remove(existingPerson);
                        people.Add(person);
                    }
                })
                .Returns(Task.CompletedTask);
            mock.Setup(p => p.RemoveAsync(It.IsAny<Person>()))
                .Callback<Person>(person => people.Remove(person))
                .Returns(Task.CompletedTask);

            return mock;
        }
    }
}

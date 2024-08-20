using Moq;
using Movies.Services;
using MovieWebAPI.Exceptions;
using MovieWebAPI.Mocks;

namespace MovieWebAPI
{
    public class PersonTest
    {
        [Fact]
        public void DomainPersonTest()
        {
            var person = new Person(1, "Test", "", DateTime.Now, "");

            Assert.NotNull(person);
            Assert.IsType<Person>(person);
            Assert.Equal("Test", person.FirstName);
        }


        [Fact]
        public async Task AddPersonAsyncTest()
        {
            var repositoryMock = MockPersonRepsitory.GetMock();
            var personService = new PersonService(repositoryMock.Object);

            await personService.AddPersonAsync(100, "Test", "test", DateTime.Now, "email");

            repositoryMock.Verify(r => r.AddAsync(It.IsAny<Person>()), Times.Once);
            await Assert.ThrowsAsync<NotNullEntity>(() => personService.AddPersonAsync(100, "Test", "test", DateTime.Now, "email"));

        }

        [Fact]
        public async Task GetByIdAsyncTest()
        {
            var repositoryMock = MockPersonRepsitory.GetMock();
            var personService = new PersonService(repositoryMock.Object);

            var result = await personService.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.IsType<Person>(result);
            await Assert.ThrowsAsync<NullEntity>(() => personService.GetByIdAsync(200));
        }

        public async Task GetAllAsyncTest()
        {
            var repositoryMock = MockPersonRepsitory.GetMock();
            var personService = new PersonService(repositoryMock.Object);

            await personService.AddPersonAsync(11, "Test", "test", DateTime.Now, "email");
            await personService.AddPersonAsync(12, "Test", "test", DateTime.Now, "email");
            await personService.AddPersonAsync(13, "Test", "test", DateTime.Now, "email");

            var result = await personService.GetAllAsync();

            Assert.NotNull(result);
            Assert.IsType<Person>(result);
            Assert.Equal(4, result.Count);
        }

    }
}

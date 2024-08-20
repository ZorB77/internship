using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;
using System.Linq;
using System.Threading.Tasks;

public class PersonServiceTests
{
    private PersonService _personService;
    private MyDBContext _myDBContext;

    public PersonServiceTests()
    {
        var options = new DbContextOptionsBuilder<MyDBContext>()
            .UseInMemoryDatabase(databaseName: "MovieApplicationTestDatabasePersons")
            .Options;

        _myDBContext = new MyDBContext(options);
        _myDBContext.persons.RemoveRange(_myDBContext.persons);
        _myDBContext.SaveChanges();

        _myDBContext.persons.AddRange(
            new Person { ID = 1, FirstName = "Ana", LastName = "Pop", Birthdate = new DateTime(2002, 5, 8), City = "Cluj-Napoca", Phone = "0736483956" },
            new Person { ID = 2, FirstName = "George", LastName = "Moldovan", Birthdate = new DateTime(1985, 11, 22), City = "Bucharest", Phone = "0741234567" }
        );
        _myDBContext.SaveChanges();

        _personService = new PersonService(_myDBContext);
    }

    [Fact]
    public async Task ShouldGetAllPersons()
    {
        var persons = await _personService.GetAllPersonsAsync();

        Assert.NotNull(persons);
        Assert.Equal(2, persons.Count());
    }

    [Fact]
    public async Task ShouldGetSpecificPerson()
    {
        var person = await _personService.GetPersonAsync(99999); 
        var person2 = await _personService.GetPersonAsync(1); 

        Assert.Null(person);
        Assert.NotNull(person2);
        Assert.Equal("Ana", person2.FirstName);
        Assert.Equal("Pop", person2.LastName);
    }

    [Fact]
    public async Task ShouldAddPerson()
    {
        var newPerson = new Person { ID = 3, FirstName = "Alice", LastName = "Pop", Birthdate = new DateTime(1990, 3, 15), City = "Iasi", Phone = "0751234567" };

        await _personService.AddPersonAsync(newPerson);
        var person = await _myDBContext.persons.FirstOrDefaultAsync(p => p.FirstName == "Alice" && p.LastName == "Pop");

        Assert.NotNull(person);
        Assert.Equal("Iasi", person.City);
    }

    [Fact]
    public async Task ShouldUpdatePerson()
    {
        var personToUpdate = new Person { ID = 2, FirstName = "George", LastName = "Moldovan", Birthdate = new DateTime(1985, 11, 22), City = "Bucharest", Phone = "0747654321" };

        await _personService.UpdatePersonAsync(2, personToUpdate);
        var updatedPerson = await _personService.GetPersonAsync(2);

        Assert.NotNull(updatedPerson);
        Assert.Equal("0747654321", updatedPerson.Phone);
    }

    [Fact]
    public async Task ShouldDeletePerson()
    {
        await _personService.DeletePersonAsync(2);
        var deletedPerson = await _myDBContext.persons.FirstOrDefaultAsync(p => p.ID == 2);

        Assert.Null(deletedPerson);
    }
}

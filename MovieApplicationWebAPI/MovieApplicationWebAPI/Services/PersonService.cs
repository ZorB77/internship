using Microsoft.EntityFrameworkCore;
using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;
using MovieApplicationWebAPI.Utilities;

public class PersonService
{
    private readonly MyDBContext _dbContext;

    public PersonService(MyDBContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<Person>> GetAllPersonsAsync()
    {
        return await _dbContext.persons.ToListAsync();
    }

    public async Task<Person> GetPersonAsync(int id)
    {
        return await _dbContext.persons.FirstOrDefaultAsync(p => p.ID == id);
    }

    public async Task AddPersonAsync(Person person)
    {
        _dbContext.persons.Add(person);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdatePersonAsync(int id, Person person)
    {
        var existingPerson = await _dbContext.persons.FirstOrDefaultAsync(p => p.ID == id);
        if (existingPerson != null)
        {
            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Birthdate = person.Birthdate;
            existingPerson.City = person.City;
            existingPerson.Phone = person.Phone;

            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task DeletePersonAsync(int id)
    {
        var person = _dbContext.persons.FirstOrDefault(p => p.ID == id);
        if (person != null)
        {
            _dbContext.persons.Remove(person);
            await _dbContext.SaveChangesAsync();
        }
    }
}

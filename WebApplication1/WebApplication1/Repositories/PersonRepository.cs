using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<PersonRepository> _logger;

        public PersonRepository(DataContext dataContext, IMapper mapper, ILogger<PersonRepository> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddPerson(PersonDTO personDTO)
        {
            _logger.LogInformation("AddPerson method was called! ");
            var person = _mapper.Map<Person>(personDTO);
            _dataContext.Persons.Add(person);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeletePerson(string firstname, string lastname)
        {
            _logger.LogInformation("DeletePerson method was called! ");
            var person = await _dataContext.Persons.FirstOrDefaultAsync(p => p.FirstName == firstname && p.LastName == lastname);
            _dataContext.Persons.Remove(person);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<PagedList<PersonDTO>> GetAll(Parameters parameters)
        {
            _logger.LogInformation("Get all persons method was called! ");
            var persons = _dataContext.Persons.AsQueryable();
            var pagedPersons = await PagedList<Person>.ToPagedList(persons, parameters.PageNumber, parameters.PageSize);
            var mappedPersons = _mapper.Map<List<PersonDTO>>(pagedPersons);
            var pagedPersonsDto = new PagedList<PersonDTO>(mappedPersons, pagedPersons.TotalCount, pagedPersons.CurrentPage, pagedPersons.PageSize);
            return pagedPersonsDto;
        }

        public async Task<PersonDTO> GetPerson(string firstname, string lastname)
        {
            var person = await _dataContext.Persons
               .FirstOrDefaultAsync(p => p.FirstName == firstname && p.LastName == lastname);

            return _mapper.Map<PersonDTO>(person);
        }

        public async Task UpdatePerson(string firstName, string lastName, PersonDTO personDTO)
        {

            var person = await _dataContext.Persons.FirstOrDefaultAsync(p => p.FirstName == firstName && p.LastName == lastName);
            _mapper.Map(personDTO, person);
            await _dataContext.SaveChangesAsync();
        }
    }
}

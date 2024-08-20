using WebApplication1.DTOs;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IPersonRepository
    {
        Task<PagedList<PersonDTO>> GetAll(Parameters parameters);
        Task<PersonDTO> GetPerson(string firstname, string lastname);
        Task AddPerson(PersonDTO personDTO);
        Task UpdatePerson(string firstName, string lastName, PersonDTO personDTO);
        Task DeletePerson(string firstname, string lastname);   
    }
}

using System;
using System.Collections.Generic;

namespace Movies.Services
{
    public interface IPersonService
    {
        Task AddPersonAsync(int personID, string firstname, string lastname, DateTime birthdate, string email);
        Task DeletePersonAsync(int personId);
        Task<List<Person>> FilterPersonByDateAsync(DateTime dateStart, DateTime dateStop);
        Task<List<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int personId);
        Task UpdatePersonAsync(int personID, string firstname, string lastname, DateTime birthdate, string email);
    }
}
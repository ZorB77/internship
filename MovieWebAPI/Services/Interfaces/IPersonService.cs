using System;
using System.Collections.Generic;

namespace Movies.Services
{
    public interface IPersonService
    {
        void AddPerson(int personID, string firstname, string lastname, DateTime birthday, string email);
        void DeletePerson(int personId);
        List<Person> FilterPersonByDate(DateTime dateStart, DateTime dateStop);
        List<Person> GetAll();
        Person GetById(int personId);
        void UpdatePerson(int personID, string firstname, string lastname, DateTime birthday, string email);
    }
}
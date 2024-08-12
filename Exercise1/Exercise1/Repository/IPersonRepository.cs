using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
   public interface IPersonRepository
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPerson(string firstname, string lastname);
        void AddPerson(Person person); 
        void UpdatePerson(Person person);
        void DeletePerson(string firstname, string lastname);
    }
}

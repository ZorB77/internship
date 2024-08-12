using Exercise1.Models;
using Exercise1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Services
{
    public class PersonService
    {

        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        //add new person
        public void AddNewPerson()
        {
            var person = new Person
            {
                FirstName = Validation("Enter the first name of the person: "),
                LastName = Validation("Enter the last name of the person: "),
                Email = Validation("Enter the email of the person: ")
            };
            Console.Write("Enter the birthday of the person (yyyy-MM-dd): ");
            person.Birthday = DateTime.Parse(Console.ReadLine());

            _personRepository.AddPerson(person);
            Console.WriteLine("Person added!");
        }
        //get all persons
        public void GetPersons()
        {
            var persons = _personRepository.GetAllPersons();
            foreach (var person in persons)
            {
                Console.WriteLine($"First name: {person.FirstName}, Last name: {person.LastName}, Birthday: {person.Birthday}, Email: {person.Email}"); 
            }
        }
        public void DeleteAnyPerson()
        {
            string firstname = Validation("Please enter the first name of the person you want to delete: ");
            string lastname = Validation("Please enter the last name of the person you want ot delete: ");
            _personRepository.DeletePerson(firstname, lastname);
        }

        public void UpdatePerson()
        {
            string firstname = Validation("Please enter the first name of the person you want to update: ");
            string lastname = Validation("Please enter the last name of the person you want to update: ");
            var person = _personRepository.GetPerson(firstname, lastname);

            if(person != null)
            {
                Console.WriteLine("Enter new firstname or leave empty to keep the current firstname: ");
                string newFirstName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newFirstName))
                {
                    person.FirstName = newFirstName;
                }

                Console.WriteLine("Enter new lastname or leave empty to keep the current lastname: ");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    person.LastName = newLastName;
                }

                Console.WriteLine("Enter new birthday (YYYY-MM-DD)or leave empty to keep the current birthday: ");
                string newBirthday = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newBirthday))
                {
                    person.Birthday = DateTime.Parse(newBirthday); 
                }
                Console.WriteLine("Enter new email or leave empty to keep the current email: ");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    person.Email = newEmail;
                }

            }

            _personRepository.UpdatePerson(person);
            Console.WriteLine("The person was updated");

        }
        //validating string inputs
        public string Validation(string message)
        {
            Console.Write(message);
            string inputUser = Console.ReadLine();
            while (inputUser == null)
            {
                Console.Write("Please introduce the required information!");
                Console.Write(message);
                inputUser = Console.ReadLine();
            }
            return inputUser;
        }
        //method for validating int inputs

        public int ValidationInt(string message, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            Console.WriteLine(message);
            string inputUser = Console.ReadLine();
            int intValue;
            while (!int.TryParse(inputUser, out intValue) || intValue < minValue || intValue > maxValue)
            {
                Console.WriteLine($"The entry must be between {minValue} and {maxValue}");
                Console.Write(message);
                inputUser = Console.ReadLine();
            }
            return intValue;
        }
    }
}

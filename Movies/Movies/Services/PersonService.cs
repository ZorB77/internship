using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Services
{
    internal class PersonService
    {
        private readonly Repository<Person> _repository;

        public PersonService(Repository<Person> repository)
        {
            _repository = repository;
        }

        public void AddPerson(int personID, string firstname, string lastname, DateTime birthday, string email)
        {
            try
            {
                if (personID == null)
                {
                    throw new Exception("Error: the id must not be null");
                }
                else if (_repository.GetById(personID) != null)
                {
                    throw new Exception("Error: there is already a person with this id");
                }
                else if (string.IsNullOrEmpty(firstname))
                {
                    throw new Exception("Error: the firstname of the person must not be null");

                }
                else if (string.IsNullOrEmpty(lastname))
                {
                    throw new Exception("Error: the lastname of the person must not be null");

                }
               
                _repository.Add(new Person(personID, firstname, lastname, birthday, email));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public List<Person> GetAll()
        {

            return _repository.GetAll().ToList();
        }

        public Person GetById(int personId)
        {
            try
            {
                if (_repository.GetById(personId) == null)
                {
                    throw new Exception("Error: there is no person with this id");
                }
                return _repository.GetById(personId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void UpdatePerson(int personID, string firstname, string lastname, DateTime birthday, string email)
        {
            try
            {
                if (_repository.GetById(personID) == null)
                {
                    throw new Exception("Error: there is no person with this id");
                }

                _repository.Update(new Person(personID, firstname, lastname, birthday, email));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DeletePerson(int personId)
        {
            try
            {
                if (_repository.GetById(personId) == null)
                {
                    throw new Exception("Error: there is no person with this id");
                }

                _repository.Remove(GetById(personId));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}

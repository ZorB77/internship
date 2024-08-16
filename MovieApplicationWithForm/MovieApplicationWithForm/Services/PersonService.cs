using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MovieApplicationWithForm.Services
{
    public class PersonService
    {
        private HttpClient httpClient;

        public PersonService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public List<Person> GetAllPersons()
        {
            var response = httpClient.GetAsync("api/people").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<List<Person>>(jsonResponse);
        }

        public List<Person> GetPersons(string column, string criteria)
        {
            var persons = GetAllPersons();
            if (column == "Name")
            {
                persons = persons.Where(p => p.firstName.Contains(criteria) || p.lastName.Contains(criteria)).ToList();
            }
            else if (column == "City")
            {
                persons = persons.Where(p => p.city.Contains(criteria)).ToList();
            }

            return persons;
        }

        public Person GetPerson(int personId)
        {
            var response = httpClient.GetAsync($"api/people/{personId}").Result;
            response.EnsureSuccessStatusCode();
            var jsonResponse = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Person>(jsonResponse);
        }


        public Person GetPersonByFirstName(string name)
        {
            var persons = GetAllPersons();
            var person = persons.SingleOrDefault(p => p.firstName == name);
            return person;
        }

        public void AddPerson(Person person)
        {
            var personJson = JsonSerializer.Serialize(person);
            var content = new StringContent(personJson, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync("api/people", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void UpdatePerson(Person person)
        {
            var personJson = JsonSerializer.Serialize(person);
            var content = new StringContent(personJson, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync($"api/people/{person.id}", content).Result;
            response.EnsureSuccessStatusCode();
        }

        public void DeletePerson(int personId)
        {
            var response = httpClient.DeleteAsync($"api/people/{personId}").Result;
            response.EnsureSuccessStatusCode();
        }
    }
}

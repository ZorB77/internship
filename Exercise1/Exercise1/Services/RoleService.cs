using Exercise1.Models;
using Exercise1.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Services
{
    public class RoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IPersonRepository _personRepository;

        public RoleService(IRoleRepository roleRepository, IMovieRepository movieRepository, IPersonRepository personRepository)
        {
            _roleRepository = roleRepository;
            _movieRepository = movieRepository;
            _personRepository = personRepository;
        }

        public void AddNewRole()
        {
            string RoleName = Validation("Enter the name of the role: ");
            string movieName = Validation("Enter the movie name in which the role is present: ");
            var movie = _movieRepository.GetMovie(movieName);
            string personFirstName = Validation("Enter the first name of the person that has this role: ");
            string personLastName = Validation("Enter the last name of the person that has this role:  ");
            var person = _personRepository.GetPerson(personFirstName, personLastName);
            if (movie != null && person != null)
            {
                var role = new Role
                {
                    Name = RoleName,
                    Movie = movie,
                    Person = person,
                };
                _roleRepository.AddRole(role);
                Console.WriteLine("Role added to the database!");
            }
        }

        public void GetAllRoles()
        {
            var roles = _roleRepository.GetAllRoles();
            foreach (var role in roles)
            {
                Console.WriteLine($"Id: {role.ID}, Name: {role.Name}, Movie:{role.Movie.Name}, Person{role.Person.FirstName} {role.Person.LastName}");
            }
        }
        //get the role by id
        public void GetRoleById()
        {
            Console.WriteLine("Enter the roleId: ");
            if (int.TryParse(Console.ReadLine(), out var roleId))
            {
                var role = _roleRepository.GetRoleByID(roleId);
                if (role != null)
                {
                    Console.WriteLine($"Id: {role.ID}, Name: {role.Name}, Movie:{role.Movie.Name}, Person{role.Person.FirstName}");
                }
            }
        }
        //get the role by name
        public void GetRoleByName()
        {
            string roleName = Validation("Enter the role name: ");
            var role = _roleRepository.GetRoleByName(roleName);

            if (role != null)
            {
                Console.WriteLine($"Id: {role.ID}, Name: {role.Name}, Movie:{role.Movie.Name}, Person{role.Person.FirstName}");
            }
        }

        public void UpdateRole()
        {
            GetAllRoles();
            int id = ValidationInt("Please enter the id of the role you want to update: ");
            var role = _roleRepository.GetRoleByID(id);
            if (role != null)
            {
                Console.WriteLine("Enter the new role or leave empty to keep the current role: ");
                string newRoleName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newRoleName))
                {
                    role.Name = newRoleName;
                }

                Console.WriteLine("Enter new movie name or leave empty to keep the current movie name:");
                string newMovieName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newMovieName))
                {
                    var movie = _movieRepository.GetMovie(newMovieName);
                    if (movie != null)
                    {
                        role.MovieId = movie.ID;
                    }
                }

                Console.WriteLine("Enter new person's first name or leave empty to keep the curent one: ");
                string newFirstName = Console.ReadLine();
                Console.WriteLine("Enter new person's last name or leave empty to keep the current one: ");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newFirstName) && !string.IsNullOrWhiteSpace(newLastName))
                {
                    var person = _personRepository.GetPerson(newFirstName, newLastName);
                    if (person != null)
                    {
                        role.PersonId = person.ID;
                    }
                }

                _roleRepository.UpdateRole(role);
                Console.WriteLine("Role updated!");
            }

        }
        public void DeleteRole()
        {
            GetAllRoles();
            int roleId = ValidationInt(" Enter the id of the role you want to delete: ");
            _roleRepository.DeleteRole(roleId);
            Console.WriteLine("Role deleted");
        }
        //method for retreiving roles by movie name
        public void GetRolesByMovieName()
        {
            string movieName = Validation("Enter the movie name: ");
            var roles = _roleRepository.GetRolesByMovieName(movieName);

            foreach (var role in roles)
            {
                Console.WriteLine($"Id: {role.ID}, Name: {role.Name}, Movie:{role.Movie.Name}, Person{role.Person.FirstName}");
            }
        }
        //get roles by persons method
        public void GetRolesByPerson()
        {
            string firstName = Validation("Enter the person's first name: ");
            string lastName = Validation("Enter the person's last name: ");
            var role = _roleRepository.GetRoleByPersonName(firstName, lastName);

            if (role != null)
            {
                Console.WriteLine($"Id: {role.ID}, Name: {role.Name}, Movie:{role.Movie.Name}, Person{role.Person.FirstName}");
            }
        }
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

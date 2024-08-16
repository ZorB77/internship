using MovieApp.Models;
using MovieApp;

namespace MovieApplication.Services
{
    public class RoleService
    {

        private readonly MovieContext _context;

        public RoleService(MovieContext context)
        {
            _context = context;
        }

        public string AddRole(int movieId, int personId, string name)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.ID == movieId);
            var person = _context.Persons.FirstOrDefault(p => p.ID == personId);

            try
            {
                if (movie != null && person != null)
                {
                    var newRole = new Role
                    {
                        Movie = movie,
                        Person = person,
                        Name = name
                    };

                    _context.Roles.Add(newRole);
                    _context.SaveChanges();
                }
                return "Role added succesfully!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

            public List<Role> GetAllRoles()
            {
                return _context.Roles.ToList();
            }

            public Role GetRoleById(int id)
            {
                return _context.Roles.FirstOrDefault(r => r.ID == id);
            }

            public bool DeleteRole(int id)
            {
                var role = _context.Roles.FirstOrDefault(r => r.ID == id);

                if (role != null)
                {
                    _context.Roles.Remove(role);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }

            public string UpdateRole(int roleId, int movieId, int personId, string name)
            {
                var role = _context.Roles.FirstOrDefault(r => r.ID == roleId);
                var movie = _context.Movies.FirstOrDefault(m => m.ID == movieId);
                var person = _context.Persons.FirstOrDefault(p => p.ID == personId);

                if (role != null)
                {
                    role.Movie = movie;
                    role.Person = person;
                    role.Name = name;

                    _context.SaveChanges();
                    return "Role updated succesfully!";
                }
                return "Role not found! Please try again!";
            }

            public void RoleOptions()
            {
                Console.WriteLine();
                Console.WriteLine("1 - Add a role");
                Console.WriteLine("2 - Get roles list");
                Console.WriteLine("3 - Get role by id");
                Console.WriteLine("4 - Delete a role");
                Console.WriteLine("5 - Update a role");
                Console.WriteLine("6 - Back to base options");
            }
        }
    }

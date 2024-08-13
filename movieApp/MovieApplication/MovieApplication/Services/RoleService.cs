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

        public bool AddRole(int movieId, int personId, string name)
        {
            Movie movie = _context.Movies.FirstOrDefault(m => m.ID == movieId);
            Person person = _context.Persons.FirstOrDefault(p => p.ID == personId);

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
                return true;
            }
            catch (Exception ex)
            {
                return false;
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

            public bool UpdateRole(int roleId, int movieId, int personId, string name)
            {
                Role role = _context.Roles.FirstOrDefault(r => r.ID == roleId);
                Movie movie = _context.Movies.FirstOrDefault(m => m.ID == movieId);
                Person person = _context.Persons.FirstOrDefault(p => p.ID == personId);

                if (role != null)
                {
                    role.Movie = movie;
                    role.Person = person;
                    role.Name = name;

                    _context.SaveChanges();
                    return true;
                }
                return false;
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

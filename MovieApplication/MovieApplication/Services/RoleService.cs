using Microsoft.EntityFrameworkCore;
using System.Text;

namespace MovieApplication
{
    public class RoleService
    {
        private MyDBContext db;

        public RoleService(MyDBContext db)
        {
            this.db = db;
        }

        public int addRole(int movieID, int personID, string name)
        {
            Movie movie = db.movies.SingleOrDefault(m => m.movieID == movieID);
            Person person = db.persons.SingleOrDefault(p => p.personID == personID);
            if (movie != null && person != null)
            {
                db.Add(new Role { movie = movie, person = person, name = name });
                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public int deleteRole(int roleID)
        {
            var role = db.roles.SingleOrDefault(r => r.roleID == roleID);
            if (role != null)
            {
                db.Remove(role);
                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public int updateRole(int roleID, int movieID, int personID, string name)
        {
            Role role = db.roles.SingleOrDefault(r => r.roleID == roleID);
            Movie movie = db.movies.SingleOrDefault(m => m.movieID == movieID);
            Person person = db.persons.SingleOrDefault(p => p.personID == personID);
            if (role != null)
            {
                role.movie = movie;
                role.person = person;
                role.name = name;

                db.SaveChanges();
                return 0;
            }
            return 1;
        }

        public string printRoles()
        {
            var s = new StringBuilder();
            s.AppendLine();
            s.AppendLine("The list of roles is:");

            foreach (Role role in db.roles.Include(r => r.movie).Include(r => r.person))
            {
                s.AppendLine($"{role.roleID}. Movie: {role.movie.name}. Person: {role.person.firstName}. Role: {role.name}");
            }
            return s.ToString();
        }

        public string getRoleInformation(int roleID)
        {
            var s = new StringBuilder();
            s.AppendLine();

            var role = db.roles.Include(r => r.movie).Include(r => r.person).SingleOrDefault(r => r.roleID == roleID);
            if (role != null)
            {
                s.AppendLine($"Movie: {role.movie.name}");
                s.AppendLine($"Person: {role.person.firstName}");
                s.AppendLine($"Comment: {role.name}");
            }
            else
            {
                s.AppendLine("There is no role with such id.");
            }
            return s.ToString();
        }

        public void printMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add a role.");
            Console.WriteLine("2. Delete a role.");
            Console.WriteLine("3. Update a role.");
            Console.WriteLine("4. See all role.");
            Console.WriteLine("5. See information about a given role.");
            Console.WriteLine("0. Back to the main menu.");
        }
    }
}

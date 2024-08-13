using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieWinForms;
using MovieWinForms.Models;
namespace MovieWinForms.DataAccess
{
    public class RoleRepository 
    {
        private static MovieDbContext _context = new MovieDbContext();
        public static void CreateRole(int movieId, int personId, string roleName)
        {
            var role = new Role();
            role.Name = roleName;
            role.Movie = _context.Movies.Where(x => x.Id == movieId).FirstOrDefault();
            role.Person = _context.People.Where(x => x.Id == personId).FirstOrDefault();
            _context.Roles.Add(role);
            _context.SaveChanges();
        }
        public static List<Role> GetRolesForMovie(int movieId)
        {
            var roles = _context.Roles.Where(m => m.Movie.Id == movieId).ToList();
            return roles;
        }
        public static Role GetRoleById(int id)
        {
            return _context.Roles.Include(r => r.Person).Where(r => r.Id == id).FirstOrDefault();
        }
        public static void UpdateRole(int id, string name)
        {
            var role = GetRoleById(id);
            role.Name = name;
            _context.Update(role);
            _context.SaveChanges();
        }
        public static void DeleteRole(int id)
        {
            var role = GetRoleById(id);
            _context.Remove(role);
            _context.SaveChanges();
        }
    }
}

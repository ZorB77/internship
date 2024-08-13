using Exercise1.ConfigDatabase;
using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise1.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MovieContext _movieContext;

        public RoleRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        public void AddRole(Role role)
        {
           
            _movieContext.Roles.Add(role);
            _movieContext.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var role = _movieContext.Roles.Find(id);
            if (role != null)
            {
                _movieContext.Roles.Remove(role);
                _movieContext.SaveChanges();
            }
        }


        

        public IEnumerable<Role> GetAllRoles()
        {
            return _movieContext.Roles.Include(r => r.Movie).Include(r => r.Person).ToList();
        }

        public Role GetRoleByID(int id)
        {
            return _movieContext.Roles.Include(r => r.Movie).Include(r => r.Person).FirstOrDefault(r => r.ID == id);
        }

        public Role GetRoleByName(string name)
        {
            return _movieContext.Roles.Include(r => r.Movie).Include(r => r.Person).FirstOrDefault(r => r.Name.ToLower() == name.ToLower());

        }

        public Role GetRoleByPersonName(string firstName, string lastName)
        {
            return _movieContext.Roles.Include(r => r.Movie).Include(r => r.Person).Where(r => r.Person.FirstName == firstName && r.Person.LastName == lastName).FirstOrDefault();

        }
            public IEnumerable<Role> GetRolesByMovieName(string movieName)
        {
            return _movieContext.Roles.Include(r =>r.Movie).Include(r =>r.Person).Where(r => r.Movie.Name.ToLower() == movieName.ToLower()).ToList();
        }

        public void UpdateRole(Role role)
        {
           
            _movieContext.SaveChanges();
        }
    }
}

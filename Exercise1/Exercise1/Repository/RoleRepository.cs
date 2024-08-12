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
            return _movieContext.Roles.Include("Movie").Include("Person").ToList();
        }

        public Role GetRoleByID(int id)
        {
            return _movieContext.Roles.Include("Movie").Include("Person").FirstOrDefault(r => r.RoleID == id);
        }

        public Role GetRoleByName(string name)
        {
            return _movieContext.Roles.Include("Movie").Include("Person").FirstOrDefault(r => r.Name.ToLower() == name.ToLower());

        }

        public Role GetRoleByPersonName(string firstName, string lastName)
        {
            return _movieContext.Roles.Include("Movie").Include("Person").FirstOrDefault(r => r.Person.FirstName.ToLower() == firstName.ToLower()&& r.Person.LastName.ToLower() == lastName.ToLower());
        }

        public IEnumerable<Role> GetRolesByMovieName(string movieName)
        {
            return _movieContext.Roles.Include("Movie").Include("Person").Where(r => r.Movie.Name.ToLower() == movieName.ToLower()).ToList();
        }

        public void UpdateRole(Role role)
        {
            _movieContext.Roles.Attach(role);
            _movieContext.Entry(role).State = EntityState.Modified;
            _movieContext.SaveChanges();
        }
    }
}

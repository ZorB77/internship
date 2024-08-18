using ETMovies.DatabaseContext;
using ETMovies.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.Service
{
    public class RoleService
    {
        public MyDbContext Context;

        public RoleService(MyDbContext context)
        {  
            Context = context; 
        }

        #region RolesCRUD

        // Add a role
        public void AddRole(string name, int movieID, int personID)
        {
            if (movieID != null && personID != null)
            {
                var movie = Context.Movies.FirstOrDefault(m => m.ID == movieID);
                var person = Context.Persons.FirstOrDefault(p => p.ID == personID);
                var role = new Role(movie, person, name);
                Context.Roles.Add(role);
                Context.SaveChanges();
            }


        }

        // Select * roles
        public List<Role> GetRoles()
        {
            return Context.Roles.AsNoTracking().Include(r => r.Person).Include(r=>r.Movie).AsEnumerable().ToList();

        }

        // Update a role

        public void UpdateRole(int index, int movieID, int personID, string name)
        {
            var roleToUpdate = Context.Roles.FirstOrDefault(m => m.ID == index);
            if (roleToUpdate != null)
            {
                roleToUpdate.Movie.ID = movieID;
                roleToUpdate.Person.ID = personID;
                roleToUpdate.Name = name;
                Context.SaveChanges();
            }
        }

        // Delete a role

        public void DeleteRole(int index)
        {
            var roleToDelete = Context.Roles.FirstOrDefault(m => m.ID == index);
            if (roleToDelete != null)
            {
                Context.Roles.Remove(roleToDelete);
                Context.SaveChanges();
            }
        }

        public Role GetRole(int id)
        {
            var review = Context.Roles.AsNoTracking().FirstOrDefault(r => r.ID == id);
            return review;
        }
        #endregion

        public List<string> FilterActorsByRole(string role)
        {

            return Context.Roles.AsNoTracking().Where(r => r.Name == role).Select(r => r.Person.FirstName + " " + r.Person.LastName).AsEnumerable().ToList();

        }

        public void addRole2(Role role)
        { 
            Context.Roles.Add(role);
        }

    }
}

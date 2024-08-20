using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.Repository
{
    public interface IRoleRepository
    {
        void AddRole(Role role);
        IEnumerable<Role> GetAllRoles();
        Role GetRoleByID(int id);
        Role GetRoleByName(string name);
        void UpdateRole(Role role);
        void DeleteRole(int id);

        IEnumerable<Role> GetRolesByMovieName(string movieName);
        Role GetRoleByPersonName(string firstName, string lastName);


    }
}

using MovieApp.Models;

namespace MovieApplication.Services.Interfaces
{
    public interface IRoleService
    {
        public bool AddRole(int movieId, int personId, string name);
        public List<Role> GetAllRoles();
        public Role GetRoleById(int id);
        public bool DeleteRole(int id);
        public bool UpdateRole(int roleId, int movieId, int personId, string name);
        public void RoleOptions();
    }
}

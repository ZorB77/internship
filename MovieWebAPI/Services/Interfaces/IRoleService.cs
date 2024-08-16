namespace MovieWebAPI.Services.Interfaces
{
    public interface IRoleService
    {
        void AddRole(int roleId, int movieId, int personId, string name, string description);
        void DeleteRole(int roleId);
        List<Role> GetAll();
        List<Role> GetRolesOfAPerson(int personId);
        void UpdateRole(int roleId, int movieId, int personId, string name, string description);
    }
}
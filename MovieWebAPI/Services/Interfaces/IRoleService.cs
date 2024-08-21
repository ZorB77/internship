namespace MovieWebAPI.Services.Interfaces
{
    public interface IRoleService
    {
        Task AddRoleAsync(int roleId, int movieId, int personId, string name, string description);
        Task DeleteRoleAsync(int roleId);
        Task<List<Role>> GetAllAsync();
        Task<List<Role>> GetRolesOfAPersonAsync(int personId);
        Task UpdateRoleAsync(int roleId, int movieId, int personId, string name, string description);
    }
}
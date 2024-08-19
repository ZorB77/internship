using WebApplication1.DTOs;

namespace WebApplication1.Repositories
{
    public interface IRoleRepository
    {

        Task AddRole(RoleDTO roleDTO, string movieName, string firstName, string lastName);
        Task<IEnumerable<RoleDTO>> GetAllRoles();
        Task<RoleDTO> GetRoleByID(int id);
        Task<RoleDTO> GetRoleByName(string name);
        Task UpdateRole(int id,RoleDTO roleDTO);
        Task DeleteRole(int id);

        Task<IEnumerable<RoleDTO>> GetRolesByMovieName(string movieName);
        Task<RoleDTO> GetRoleByPersonName(string firstName, string lastName);
    }
}

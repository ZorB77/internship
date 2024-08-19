using WebApplication1.DTOs;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IStudioRepository
    {
        Task AddStudio(StudioDTO studioDTO);
        Task DeleteStudio (string name);
        Task<StudioDTO> GetStudioByName (string name);
        Task<PagedList<StudioDTO>> GetAllStudios (Parameters parameters);
        Task UpdateStudio (StudioDTO studioDTO,string name);

    }
}

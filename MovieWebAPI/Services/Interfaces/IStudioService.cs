using System.Collections.Generic;

namespace MovieWebAPI.Services.Interfaces
{
    public interface IStudioService
    {
        Task AddStudioAsync(int id, string name, int year, string location);
        Task<Studio> GetByIdAsync(int id);
        Task<List<Studio>> GetStudiosAsync();
    }
}
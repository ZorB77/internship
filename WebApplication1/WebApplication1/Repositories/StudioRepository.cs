using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Helper;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class StudioRepository :IStudioRepository

    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<StudioRepository> _logger;
        public StudioRepository(DataContext dataContext, IMapper mapper, ILogger<StudioRepository> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddStudio(StudioDTO studioDTO)
        {
            _logger.LogInformation("AddStudio method was called! ");
            var studio = _mapper.Map<Studio>(studioDTO);
            _dataContext.Studios.Add(studio);   
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteStudio(string name)
        {
            _logger.LogInformation("DeleteStudio method was called! ");
            var studio = await _dataContext.Studios.FirstOrDefaultAsync(m => m.StudioName == name);

            if (studio != null)
            {
                _dataContext.Studios.Remove(studio);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<PagedList<StudioDTO>> GetAllStudios(Parameters parameters)
        {
            _logger.LogInformation("GetAllStudios method was called! ");
            var studios = _dataContext.Studios.AsQueryable();
            var pagedStudios = await PagedList<Studio>.ToPagedList(studios, parameters.PageNumber, parameters.PageSize);
            var mappedStudios = _mapper.Map<List<StudioDTO>>(pagedStudios);
            var pagedStudiosDto = new PagedList<StudioDTO>(mappedStudios, pagedStudios.TotalCount, pagedStudios.CurrentPage, pagedStudios.PageSize);
            return pagedStudiosDto;
        }

        public async Task<StudioDTO> GetStudioByName(string name)
        {
            var studio = await _dataContext.Studios.FirstOrDefaultAsync(m => m.StudioName == name);
            return _mapper.Map<StudioDTO>(studio);
        }

        public async Task UpdateStudio(StudioDTO studioDTO, string name)
        {
            var studio = await _dataContext.Studios.FirstOrDefaultAsync(s => s.StudioName == name);
            if (studio != null)
            {
                _mapper.Map(studioDTO, studio);
                //_dataContext.Entry(studio).State = EntityState.Modified;
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}

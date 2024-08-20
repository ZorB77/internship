using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class RoleRepository :IRoleRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleRepository> _logger;   

        public RoleRepository(DataContext dataContext, IMapper mapper, ILogger<RoleRepository> logger)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task AddRole(RoleDTO roleDTO, string movieName, string firstName, string lastName)
        {
            _logger.LogInformation("AddRole method was called! ");
            var movie = await _dataContext.Movies.FirstOrDefaultAsync(m => m.Name == movieName);
            var person = await _dataContext.Persons.FirstOrDefaultAsync(p => p.FirstName == firstName && p.LastName == lastName);
            var role = _mapper.Map<Role>(roleDTO);
            role.MovieId = movie.Id;
            role.PersonId = person.Id;
            _dataContext.Roles.Add(role);
            await _dataContext.SaveChangesAsync();

        }

        public async Task DeleteRole(int id)
        {
            _logger.LogInformation("DeleteRole method was called! ");
            var role = await _dataContext.Roles.FirstOrDefaultAsync(r=>r.Id== id);
            _dataContext.Roles.Remove(role);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoleDTO>> GetAllRoles()
        {
            _logger.LogInformation("GetAllRoles method was called! ");
            var role = await _dataContext.Roles.Include(r => r.Movie).Include(r => r.Person).ToListAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(role);
        }

        public async Task<RoleDTO> GetRoleByID(int id)
        {
            var role = await _dataContext.Roles.Include(r => r.Movie).Include(r =>r.Person).FirstOrDefaultAsync(r => r.Id == id);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<RoleDTO> GetRoleByName(string name)
        {
           var role = await _dataContext.Roles.Include(r=> r.Movie).Include(r=>r.Person).FirstOrDefaultAsync(r=> r.Name== name);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<RoleDTO> GetRoleByPersonName(string firstName, string lastName)
        {
            var role = await _dataContext.Roles.Include(r => r.Movie).Include(r => r.Person).FirstOrDefaultAsync(r => r.Person.FirstName == firstName && r.Person.LastName == lastName);
            return _mapper.Map<RoleDTO>(role);
        }

        public async Task<IEnumerable<RoleDTO>> GetRolesByMovieName(string movieName)
        {
            var roles = await _dataContext.Roles.Include(r =>r.Movie).Include(r => r.Person).Where(r => r.Movie.Name == movieName).ToListAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public async Task UpdateRole(int id, RoleDTO roleDTO)
        {
            _logger.LogInformation("UpdateRole method was called! ");
            var role = await _dataContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
            _mapper.Map(roleDTO, role);
            await _dataContext.SaveChangesAsync();
        }
    }
}

using Movies.Persistance;
using MovieWebAPI.Persistance;
using MovieWebAPI.Services.Interfaces;

namespace Movies.Services
{
    internal class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Person> _personRepository;

        public RoleService(IRoleRepository repository, IRepository<Movie> movieRepository, IRepository<Person> personRepository)
        {
            _repository = repository;
            _movieRepository = movieRepository;
            _personRepository = personRepository;
        }

        public async Task AddRoleAsync(int roleId, int movieId, int personId, string name, string description)
        {
            try
            {
                var movie = await _movieRepository.GetByIdAsync(movieId);
                if (movie == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                var person = await _personRepository.GetByIdAsync(personId);
                if (person == null)
                {
                    throw new Exception("Error: there is no person with this id");
                }

                if (name == null)
                {
                    throw new Exception("Error: the role name must not be null");
                }

                var role = new Role(roleId, movie, person, name, description);
                await _repository.AddAsync(role);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Role>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();
            return roles.ToList();
        }

        public async Task UpdateRoleAsync(int roleId, int movieId, int personId, string name, string description)
        {
            try
            {
                var role = await _repository.GetByIdAsync(roleId);
                if (role == null)
                {
                    throw new Exception("Error: there is no role with this id");
                }

                var movie = await _movieRepository.GetByIdAsync(movieId);
                var person = await _personRepository.GetByIdAsync(personId);

                var updatedRole = new Role(roleId, movie, person, name, description);
                await _repository.UpdateAsync(updatedRole);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            try
            {
                var role = await _repository.GetByIdAsync(roleId);
                if (role == null)
                {
                    throw new Exception("Error: there is no role with this id");
                }

                await _repository.RemoveAsync(role);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<Role>> GetRolesOfAPersonAsync(int personId)
        {
            var roles = await _repository.GetAllAsync();
            return roles.Where(r => r.Person.PersonId == personId).ToList();
        }
    }
}

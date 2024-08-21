using Movies.Persistance;
using MovieWebAPI.Exceptions;
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

            var movie = await _movieRepository.GetByIdAsync(movieId);

            if (movie == null)
            {
                throw new NullEntity(movieId, "Movie");
            }

            var person = await _personRepository.GetByIdAsync(personId);

            if (person == null)
            {
                throw new NullEntity(personId, "Person");
            }

            var role = await _repository.GetByIdAsync(roleId);

            if (role != null)
            {
                throw new NotNullEntity("There is already a role with this id");

            }

            role = new Role(roleId, movie, person, name, description);
            await _repository.AddAsync(role);
        }

        public async Task<List<Role>> GetAllAsync()
        {
            var roles = await _repository.GetAllAsync();

            if (roles == null)
            {
                throw new NullList("There is no roles in our database");
            }
            return roles.ToList();
        }

        public async Task UpdateRoleAsync(int roleId, int movieId, int personId, string name, string description)
        {

            var role = await _repository.GetByIdAsync(roleId);

            if (role == null)
            {
                throw new NullEntity(roleId, "Role");
            }

            var movie = await _movieRepository.GetByIdAsync(movieId);
            var person = await _personRepository.GetByIdAsync(personId);

            var updatedRole = new Role(roleId, movie, person, name, description);
            await _repository.UpdateAsync(updatedRole);
        }

        public async Task DeleteRoleAsync(int roleId)
        {

            var role = await _repository.GetByIdAsync(roleId);

            if (role == null)
            {
                throw new NullEntity(roleId, "Role");
            }

            await _repository.RemoveAsync(role);
        }

        public async Task<List<Role>> GetRolesOfAPersonAsync(int personId)
        {
            var person = await _personRepository.GetByIdAsync(personId);

            if (person == null)
            {
                throw new NullEntity(personId, "Person");
            }
            var roles = await _repository.GetAllAsync();
            return roles.Where(r => r.Person.PersonId == personId).ToList();
        }
    }
}
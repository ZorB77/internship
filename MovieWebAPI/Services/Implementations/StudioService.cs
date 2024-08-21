using MovieWebAPI.Exceptions;
using MovieWebAPI.Persistance;
using MovieWebAPI.Services.Interfaces;


namespace Movies.Services
{
    internal class StudioService : IStudioService
    {
        private readonly IRepository<Studio> _repository;

        public StudioService(IRepository<Studio> repository)
        {
            _repository = repository;
        }

        public async Task AddStudioAsync(int id, string name, int year, string location)
        {

            var existingStudio = await _repository.GetByIdAsync(id);
            if (existingStudio != null)
            {
                throw new NotNullEntity("There is already a studio with this id");
            }

            await _repository.AddAsync(new Studio(id, name, year, location));
        }
        public async Task<Studio> GetByIdAsync(int id)
        {

            var studio = await _repository.GetByIdAsync(id);
            if (studio == null)
            {
                throw new NullEntity(id, "Studio");
            }
            return studio;
        }

        public async Task<List<Studio>> GetStudiosAsync()
        {
            var studios = await _repository.GetAllAsync();

            if (studios == null)
            {
                throw new NullList("There is no studio in our database");
            }
            return studios.ToList();
        }

    }
}

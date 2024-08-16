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
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
                }

                if (string.IsNullOrEmpty(location))
                {
                    throw new ArgumentException($"'{nameof(location)}' cannot be null or empty.", nameof(location));
                }

                await _repository.AddAsync(new Studio(id, name, year, location));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public async Task<Studio> GetByIdAsync(int id)
        {
            try
            {
                var studio = await _repository.GetByIdAsync(id);
                if (studio == null)
                {
                    throw new Exception("Error: there is no review with this id");
                }
                return studio;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task<List<Studio>> GetStudiosAsync()
        {
            var studios = await _repository.GetAllAsync();
            return studios.ToList();
        }

    }
}

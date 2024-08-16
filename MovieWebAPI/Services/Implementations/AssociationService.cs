using Movies.Persistance;
using MovieWebAPI.Persistance;

namespace Movies.Services
{
    internal class AssociationService : IAssociationService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<Studio> _studioRepository;
        private readonly IAssociationRepository _repository;

        public AssociationService(IRepository<Movie> movieRepository,
                                  IRepository<Studio> studioRepository,
                                  IAssociationRepository repository)
        {
            _movieRepository = movieRepository;
            _studioRepository = studioRepository;
            _repository = repository;
        }

        public async Task AddAssociationAsync(int id, int movieId, int studioId)
        {
            try
            {
                var movie = await _movieRepository.GetByIdAsync(movieId);
                if (movie == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                var studio = await _studioRepository.GetByIdAsync(studioId);
                if (studio == null)
                {
                    throw new Exception("Error: there is no studio with this id");
                }

                var association = new MovieStudioAssociation(id, movie, studio);
                await _repository.AddAsync(association);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task<List<MovieStudioAssociation>> GetAllAssociationsAsync()
        {
            var associations = await _repository.GetAllAsync();
            return associations.ToList();
        }
    }
}

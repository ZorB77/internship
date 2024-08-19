using Microsoft.CodeAnalysis.CSharp.Syntax;
using Movies.Persistance;
using MovieWebAPI.Exceptions;
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

            var movie = await _movieRepository.GetByIdAsync(movieId);
            if (movie == null)
            {
                throw new NullEntity(movieId, "movieId");
            }

            var studio = await _studioRepository.GetByIdAsync(studioId);
            if (studio == null)
            {
                throw new NullEntity(studioId, "Studio");
            }

            var association = await _repository.GetByIdAsync(id);
            if (association != null)
            {
                throw new NotNullEntity("There is already a movie - studio associaition with this id");
            }

            association = new MovieStudioAssociation(id, movie, studio);
            await _repository.AddAsync(association);
        }

        public async Task<List<MovieStudioAssociation>> GetAllAssociationsAsync()
        {
            var associations = await _repository.GetAllAsync();

            if (associations == null)
            {
                throw new NullList("No Associations movie - studio in our Database");
            }
            return associations.ToList();
        }
    }
}

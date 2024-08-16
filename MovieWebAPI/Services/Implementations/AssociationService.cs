using Movies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddAssociation(int id, int movieId, int studioId)
        {
            try
            {
                if (_movieRepository.GetById(movieId) == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                if (_studioRepository.GetById(studioId) == null)
                {
                    throw new Exception("Error: there is no studio with this id");
                }

                _repository.Add(new MovieStudioAssociation(id, _movieRepository.GetById(movieId), _studioRepository.GetById(studioId)));

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public List<MovieStudioAssociation> GetAllAssociations()
        {
            return _repository.GetAll().ToList();
        }
    }
}

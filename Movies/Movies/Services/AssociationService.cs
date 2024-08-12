using Movies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Services
{
    internal class AssociationService
    {

        private readonly Repository<Movie> _movieRepository;
        private readonly Repository<Studio> _studioRepository;
        private readonly AssociationRepository _repository;

        public AssociationService(Repository<Movie> movieRepository,
                                             Repository<Studio> studioRepository,
                                             AssociationRepository repository)
        {
            _movieRepository = movieRepository; 
            _studioRepository = studioRepository;
            _repository = repository;
        }

        public void AddAssociation(int id, int movieId, int studioId)
        {
            try
            {
                if(_movieRepository.GetById(movieId) == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                if (_studioRepository.GetById(studioId) == null)
                {
                    throw new Exception("Error: there is no studio with this id");
                }

                _repository.Add(new MovieStudioAssociation(id, _movieRepository.GetById(movieId), _studioRepository.GetById(studioId)));

            } catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public List<MovieStudioAssociation> GetAllAssociations() 
        {
            return _repository.GetAll().ToList();
        }
    }
}

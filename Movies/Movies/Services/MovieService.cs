using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Services
{
    internal class MovieService
    {
        private readonly Repository<Movie> _repository;

        public MovieService(Repository<Movie> repository)
        {
            _repository = repository;
        }

        public void AddMovie(int movieId, string name, int year, string description, string genre)
        {
            try
            {
                if (movieId == null)
                {
                    throw new Exception("Error: the id must not be null");
                } 
                else if (_repository.GetById(movieId) != null)
                {
                    throw new Exception("Error: there is already a movie with this id");
                }
                else if(string.IsNullOrEmpty(name))
                {
                    throw new Exception("Error: the name of the movie must not be null");

                }
                else if (year < 0 && year > 10000) {
                    throw new Exception("Error: the year of the movie is not valid");

                }

                _repository.Add(new Movie(movieId, name, year, description, genre));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public List<Movie> GetAll()
        {
            var movies = _repository.GetAll();

            return movies.ToList();
        }

        public Movie GetById(int movieId)
        {
            try
            {
                if (_repository.GetById(movieId) == null)
                {
                    throw new Exception("Error: there is no movie this id");
                }
                return _repository.GetById(movieId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

            public void UpdateMovie(int movieId, string name, int year, string description, string genre)
        {
            try
            {
                if (_repository.GetById(movieId) == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                _repository.Update(new Movie(movieId, name, year, description, genre));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteMovie(int movieId)
        {
            try
            {
                if (_repository.GetById(movieId) == null)
                {
                    throw new Exception("Error: there is no movie with this id");
                }

                _repository.Remove(GetById(movieId));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public List<Movie> SortbyTitle()
        {
            return _repository.GetAll().OrderBy(movie => movie.Name).ToList();
        }

        public List<Movie> SortbyYear()
        {
            return _repository.GetAll().OrderBy(movie => movie.Year).ToList();
        }

        public List<Movie> FilterMoviesByDate(DateTime dateStart, DateTime dateStop)
        {
            return _repository.GetAll().Where(movie => movie.Year >= dateStart.Year && movie.Year <= dateStop.Year).ToList();
        }

        public List<Movie> FilterMoviesByGenre(string genre)
        {
            return _repository.GetAll().Where(movie => movie.Genre.ToLower() == genre.ToLower()).ToList();
        }

        public bool CheckIfExists(int id)
        {

            if (_repository.GetById(id) == null)
            {
                return false;
            }
            return true;


        }

        public List<Movie> FilterMoviesByYear(int year)
        {
            return _repository.GetAll().Where(movie => movie.Year == year).ToList();
        }

    }
}
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using WebApplication1.Controllers;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace TestProject2
{
    [TestFixture]
    public class Tests
    {

        private MovieController _movieController;
        private IMovieRepository _movieRepository;
        [SetUp]
        public void Setup()
        {
            _movieRepository = Substitute.For<IMovieRepository>();

            _movieController = new MovieController(_movieRepository);
        }

        [Test]
        public async Task GetMovieByName()
        {
            //arrange
            var movieName = "The Future of Us";
            var movieDTO = new MovieDTO { Name = movieName };
          _movieRepository.GetMovieByName(movieName).Returns(Task.FromResult(movieDTO));
            //act
            var result = await _movieController.GetMovieByName(movieName);

            //assert
            var okResult = result.Result as OkObjectResult;
            var returnedMovie = okResult.Value as MovieDTO;
            Assert.AreEqual(movieName, returnedMovie.Name);

        }
        [Test]
        public async Task DeleteMovie()
        {
            //arrange
            var movieName = "The Future of Us";
            var movieDTO = new MovieDTO { Name = movieName };
            _movieRepository.GetMovieByName(movieName).Returns(Task.FromResult(movieDTO));

            //act
            var result = await _movieController.DeleteMovie(movieName);

            //assert
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}
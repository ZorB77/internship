using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.Repositories;

namespace TestProject2
{
    [TestFixture]
    public class MovieStudioTest
    {
        private MovieStudioController _movieStudioController;
        private IMovieStudioRepository _movieStudioRepository;

        [SetUp]
        public void Setup()
        {
            _movieStudioRepository = Substitute.For<IMovieStudioRepository>();
            _movieStudioController = new MovieStudioController(_movieStudioRepository);

        }
        [Test]
        public async Task AddMovieStudio()
        {
            //arrange
            var movieName = " The Future of Us";
            var studioName = "baba";

            //act
            var result = await _movieStudioController.AddMovieStudio(movieName, studioName);

            //assert
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
          
        }
        [Test]
        public async Task DeleteMovieStudio()
        {//arrange
            var movieName = "The Future of Us";
            var studioName = "baba";
            //act
            var result = await _movieStudioController.DeleteMovieStudio(movieName, studioName);
            //assert
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}

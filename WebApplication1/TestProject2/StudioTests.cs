using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.DTOs;
using WebApplication1.Repositories;

namespace TestProject2
{
    [TestFixture]
    public class StudioTests
    {
        private StudioController _studioController;
        private IStudioRepository _studioRepository;

        [SetUp]
        public void Setup()
        {
            _studioRepository = Substitute.For<IStudioRepository>();
            _studioController = new StudioController(_studioRepository);
        }

        [Test]
        public async Task GetStudioByName()
        {
            //arrange
            var studioName = "Pixar";
            var studio = new StudioDTO
            {
                StudioName = studioName,
                StudioLocation = "buc",
                StudioYear = 2022
            };

            //act
            var result = await _studioController.GetStudioByName(studioName);

            //assert
            var okResult = result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [Test]
        public async Task DeleteStudio()
        {
            //arrange
            var studioName = "Pixar";
            var studio = new StudioDTO
            {
                StudioName = studioName,
              
            };
            _studioRepository.GetStudioByName(studioName).Returns(Task.FromResult(studio));

            //act
            var result = await _studioController.DeleteStudio(studioName);

            //assert
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}

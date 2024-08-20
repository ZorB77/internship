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
    public class RoleTests
    {
        private RoleController _roleController;
        private IRoleRepository _roleRepository;
        [SetUp]
        public void Setup()
        {
            _roleRepository = Substitute.For<IRoleRepository>();
            _roleController = new RoleController(_roleRepository);
        }

        [Test]
        public async Task GetRoleByMovieName()
        {
            //arrange
            var movieName = "Inception";
            var roles = new List<RoleDTO>
            {
                new RoleDTO { Name = "Actor", RoleDescription = "Lead Actor" , MovieAppereances = 11},
                new RoleDTO { Name = "Director", RoleDescription = "Movie Director" , MovieAppereances=10}
            };
             //act
            var result = await _roleController.GetRolesByMovieName(movieName);
            //assert
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public async Task GetRolesByMovieName()
        {
            //arrange
            var movieName = "The Future of Us";
            var roles = new List<RoleDTO>
            {
                new RoleDTO { Name = "Actor", RoleDescription = "Lead Actor",MovieAppereances = 11 },
                new RoleDTO { Name = "Actor", RoleDescription = "Simple Actor", MovieAppereances =10 }
            };
            //act
            var result = await _roleController.GetRolesByMovieName(movieName);
            //assert
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }
    }
}

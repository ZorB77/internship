using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace TestProject2
{
    public class PersonTests
    {
        private PersonController _personController;
        private IPersonRepository _personRepository;

        [SetUp]
        public void Setup()
        {
            _personRepository = Substitute.For<IPersonRepository>();
            _personController = new PersonController(_personRepository);
        }

        [Test]
        public async Task GetPerson()
        {
            //arrange
            var firstname = "Jane";
            var lastname = "Smith";
            var person = new PersonDTO
            {
                FirstName = firstname,
                LastName = lastname
            };

            _personRepository.GetPerson(firstname, lastname).Returns(Task.FromResult(person));

            //act
            var result = await _personController.GetPerson(firstname, lastname);

            //assert
            var okResult = result.Result as OkObjectResult;
            Assert.AreEqual(person, okResult.Value);
        }

        [Test]
        public async Task DeletePerson()
        { //arrange
            var firstname = "Jane";
            var lastname = "Smith";
            //act
            var result = await _personController.DeletePerson(firstname,lastname);
            //asset
            var okResult = result as OkResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}

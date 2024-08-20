using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApplicationWebAPI.DataAccess;
using MovieApplicationWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationWebAPI.Services
{

    public class RoleServiceTests
    {
        private RoleService _roleService;
        private MyDBContext _myDBContext;

        public RoleServiceTests()
        {
            var options = new DbContextOptionsBuilder<MyDBContext>()
                .UseInMemoryDatabase(databaseName: "MovieApplicationTestDatabaseRoles")
                .Options;

            _myDBContext = new MyDBContext(options);
            _myDBContext.roles.RemoveRange(_myDBContext.roles);
            _myDBContext.SaveChanges();

            var movie = new Movie { Name = "Frozen", Description = "Two sisters.", Genre = "Animation", ReleaseDate = new DateTime(2014, 12, 5) };
            var person = new Person { FirstName = "Ana", LastName = "Pop", Birthdate = new DateTime(2002, 5, 8), City = "Cluj-Napoca", Phone = "0736483956" };

            _myDBContext.roles.Add(new Role { ID = 1, Name = "Actor", Description = "Description 1", Salary = 5500, Movie = movie, Person = person });
            _myDBContext.roles.Add(new Role { ID = 2, Name = "Director", Description = "Description 2", Salary = 6000, Movie = movie, Person = person });
            _myDBContext.SaveChanges();

            _roleService = new RoleService(_myDBContext);
        }

        [Fact]
        public async Task ShouldGetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();

            Assert.NotNull(roles);
            Assert.Equal(2, roles.ToList().Count());
        }

        [Fact]
        public async Task ShouldGetSpecificRole()
        {
            var role = await _roleService.GetRoleAsync(99999);
            var role2 = await _roleService.GetRoleAsync(1);

            Assert.Null(role);
            Assert.NotNull(role2);
            Assert.Equal("Actor", role2.Name);


        }

        [Fact]
        public async Task ShouldAddRole()
        {
            var newRole = new RoleMapper { ID = 3, Name = "Regizor", Description = "Description 2", Salary = 6000, MovieID = 2, PersonID = 1 };

            await _roleService.AddRoleAsync(newRole);
            var role = await _myDBContext.roles.FirstOrDefaultAsync(m => m.Name == "Regizor");

            Assert.NotNull(role);
            Assert.Equal("Description 2", role.Description);
        }

        [Fact]
        public async Task ShouldUpdateRole()
        {
            var roleToUpdate = new RoleMapper { ID = 2, Name = "Regizor", Description = "Description updated", Salary = 6000, MovieID = 2, PersonID = 1 };

            await _roleService.UpdateRoleAsync(2, roleToUpdate);
            var updatedRole = await _roleService.GetRoleAsync(2);

            Assert.NotNull(updatedRole);
            Assert.Equal("Regizor", updatedRole.Name);
            Assert.Equal("Description updated", updatedRole.Description);
        }

        [Fact]
        public async Task ShouldDeleteRole()
        {
            await _roleService.DeleteRoleAsync(1);
            var deletedRole = await _roleService.GetRoleAsync(1);

            Assert.Null(deletedRole);
        }
    }
}

using ETMovies.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMovies.DatabaseContext
{
    public class MyDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Studio> Studios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MoviesRating;Integrated Security=True;Trust Server Certificate=True");
        }


    }
}

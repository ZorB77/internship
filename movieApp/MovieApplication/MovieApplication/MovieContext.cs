﻿using Microsoft.EntityFrameworkCore;
using MovieApp.Models;
using MovieApplication.Models;

namespace MovieApp
{
    public class MovieContext : DbContext {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> Persons { get; set; } 
        public DbSet<Role> Roles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<MovieStudio> MovieStudios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Movies;Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

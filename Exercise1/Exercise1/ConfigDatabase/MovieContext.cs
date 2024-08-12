using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1.ConfigDatabase
{
   public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public MovieContext() : base("name=MovieProject")
        {
        }
        public MovieContext(string connectionString) : base(connectionString) { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithRequired(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Roles)
                .WithRequired(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Role>()
        .HasRequired(r => r.Person)   
        .WithRequiredDependent(p => p.Role);




            base.OnModelCreating(modelBuilder);
        }

    }
}

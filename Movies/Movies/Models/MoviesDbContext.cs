using System;
using System.Data.Entity;

public class MoviesDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Review> Reviews { get; set; }
}
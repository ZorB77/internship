using Microsoft.EntityFrameworkCore;
using System;

public class MoviesDbContext(DbContextOptions<MoviesDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Studio> Studios { get; set; }
    public DbSet<MovieStudioAssociation> MovieStudioAssociations { get; set; }

}
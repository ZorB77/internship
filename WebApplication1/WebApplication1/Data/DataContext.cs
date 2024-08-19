using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<MovieStudio> MovieStudios { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Roles)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId);

            modelBuilder.Entity<Role>()
                .HasOne(r => r.Person)
                .WithOne(p => p.Role)
                .HasForeignKey<Role>(r => r.PersonId);

            modelBuilder.Entity<MovieStudio>()
                .HasKey(ms => new { ms.MovieId, ms.StudioId });

            modelBuilder.Entity<MovieStudio>()
                .HasOne(ms => ms.Movie)
                .WithMany(m => m.MovieStudios)
                .HasForeignKey(ms => ms.MovieId);

            modelBuilder.Entity<MovieStudio>()
                .HasOne(ms => ms.Studio)
                .WithMany(s => s.MovieStudios)
                .HasForeignKey(ms => ms.StudioId);

            base.OnModelCreating(modelBuilder);
        }
    }
}


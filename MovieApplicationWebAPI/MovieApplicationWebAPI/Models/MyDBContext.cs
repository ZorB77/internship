using Microsoft.EntityFrameworkCore;

namespace MovieApplicationWebAPI.Models
{
    public class MyDBContext: DbContext
    {
        public DbSet<Review> reviews { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Person> persons { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Studio> studios { get; set; }
        public DbSet<Distribution> distributions { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options)
        : base(options)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;

public class MyDBContext : DbContext
{
    public DbSet<Review> reviews { get; set; }
    public DbSet<Movie> movies { get; set; }
    public DbSet<Person> persons { get; set; }
    public DbSet<Role> roles { get; set; }
    public string dbPath { get; }

    public MyDBContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        dbPath = System.IO.Path.Join(path, "movieapplication.db");
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer($"Data Source={dbPath}");
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=movieapplication;Trusted_Connection=True;");
    }

}
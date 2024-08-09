namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProperties : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Reviews", new[] { "movie_movieId" });
            DropIndex("dbo.Roles", new[] { "movie_movieId" });
            DropIndex("dbo.Roles", new[] { "person_personId" });
            CreateIndex("dbo.Reviews", "Movie_MovieId");
            CreateIndex("dbo.Roles", "Movie_MovieId");
            CreateIndex("dbo.Roles", "Person_PersonId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Roles", new[] { "Person_PersonId" });
            DropIndex("dbo.Roles", new[] { "Movie_MovieId" });
            DropIndex("dbo.Reviews", new[] { "Movie_MovieId" });
            CreateIndex("dbo.Roles", "person_personId");
            CreateIndex("dbo.Roles", "movie_movieId");
            CreateIndex("dbo.Reviews", "movie_movieId");
        }
    }
}

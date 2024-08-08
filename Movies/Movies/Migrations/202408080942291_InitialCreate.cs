namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        movieId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        year = c.Int(nullable: false),
                        description = c.String(),
                        genre = c.String(),
                    })
                .PrimaryKey(t => t.movieId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        personId = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        birthdate = c.DateTime(nullable: false),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.personId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        reviewId = c.Int(nullable: false, identity: true),
                        rating = c.Single(nullable: false),
                        comment = c.String(),
                        movie_movieId = c.Int(),
                    })
                .PrimaryKey(t => t.reviewId)
                .ForeignKey("dbo.Movies", t => t.movie_movieId)
                .Index(t => t.movie_movieId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        roleId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        movie_movieId = c.Int(),
                        person_personId = c.Int(),
                    })
                .PrimaryKey(t => t.roleId)
                .ForeignKey("dbo.Movies", t => t.movie_movieId)
                .ForeignKey("dbo.People", t => t.person_personId)
                .Index(t => t.movie_movieId)
                .Index(t => t.person_personId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "person_personId", "dbo.People");
            DropForeignKey("dbo.Roles", "movie_movieId", "dbo.Movies");
            DropForeignKey("dbo.Reviews", "movie_movieId", "dbo.Movies");
            DropIndex("dbo.Roles", new[] { "person_personId" });
            DropIndex("dbo.Roles", new[] { "movie_movieId" });
            DropIndex("dbo.Reviews", new[] { "movie_movieId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Reviews");
            DropTable("dbo.People");
            DropTable("dbo.Movies");
        }
    }
}

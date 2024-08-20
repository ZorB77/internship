namespace Exercise1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Description = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(),
                        ReviewCreated = c.DateTime(nullable: false),
                        ReviewerFirstName = c.String(),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        RoleDescription = c.String(),
                        MovieAppereances = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.ID)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudioName = c.String(),
                        StudioYear = c.Int(nullable: false),
                        StudioLocation = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MovieStudios",
                c => new
                    {
                        Movie_ID = c.Int(nullable: false),
                        Studio_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_ID, t.Studio_ID })
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .ForeignKey("dbo.Studios", t => t.Studio_ID, cascadeDelete: true)
                .Index(t => t.Movie_ID)
                .Index(t => t.Studio_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieStudios", "Studio_ID", "dbo.Studios");
            DropForeignKey("dbo.MovieStudios", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.Roles", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Roles", "ID", "dbo.People");
            DropForeignKey("dbo.Reviews", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieStudios", new[] { "Studio_ID" });
            DropIndex("dbo.MovieStudios", new[] { "Movie_ID" });
            DropIndex("dbo.Roles", new[] { "MovieId" });
            DropIndex("dbo.Roles", new[] { "ID" });
            DropIndex("dbo.Reviews", new[] { "MovieId" });
            DropTable("dbo.MovieStudios");
            DropTable("dbo.Studios");
            DropTable("dbo.People");
            DropTable("dbo.Roles");
            DropTable("dbo.Reviews");
            DropTable("dbo.Movies");
        }
    }
}

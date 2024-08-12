namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieStudioAssociations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateStamp = c.DateTime(nullable: false),
                        Movie_MovieId = c.Int(),
                        Studio_StudioId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_MovieId)
                .ForeignKey("dbo.Studios", t => t.Studio_StudioId)
                .Index(t => t.Movie_MovieId)
                .Index(t => t.Studio_StudioId);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        StudioId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.StudioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieStudioAssociations", "Studio_StudioId", "dbo.Studios");
            DropForeignKey("dbo.MovieStudioAssociations", "Movie_MovieId", "dbo.Movies");
            DropIndex("dbo.MovieStudioAssociations", new[] { "Studio_StudioId" });
            DropIndex("dbo.MovieStudioAssociations", new[] { "Movie_MovieId" });
            DropTable("dbo.Studios");
            DropTable("dbo.MovieStudioAssociations");
        }
    }
}

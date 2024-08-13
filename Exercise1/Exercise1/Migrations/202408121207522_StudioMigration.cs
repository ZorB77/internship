namespace Exercise1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudioMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        StudioId = c.Int(nullable: false, identity: true),
                        StudioName = c.String(),
                        StudioYear = c.String(),
                        StudioLocation = c.String(),
                    })
                .PrimaryKey(t => t.StudioId);
            
            CreateTable(
                "dbo.MovieStudios",
                c => new
                    {
                        Movie_MovieID = c.Int(nullable: false),
                        Studio_StudioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Movie_MovieID, t.Studio_StudioId })
                .ForeignKey("dbo.Movies", t => t.Movie_MovieID, cascadeDelete: true)
                .ForeignKey("dbo.Studios", t => t.Studio_StudioId, cascadeDelete: true)
                .Index(t => t.Movie_MovieID)
                .Index(t => t.Studio_StudioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieStudios", "Studio_StudioId", "dbo.Studios");
            DropForeignKey("dbo.MovieStudios", "Movie_MovieID", "dbo.Movies");
            DropIndex("dbo.MovieStudios", new[] { "Studio_StudioId" });
            DropIndex("dbo.MovieStudios", new[] { "Movie_MovieID" });
            DropTable("dbo.MovieStudios");
            DropTable("dbo.Studios");
        }
    }
}

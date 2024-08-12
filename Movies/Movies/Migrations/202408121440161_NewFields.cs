namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Duration", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Roles", "Description", c => c.String());
            AddColumn("dbo.Roles", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "CreatedDate");
            DropColumn("dbo.Roles", "Description");
            DropColumn("dbo.Reviews", "DateTime");
            DropColumn("dbo.Movies", "Duration");
        }
    }
}

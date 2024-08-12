namespace Movies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCreatedDateFromRoles : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Roles", "CreatedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}

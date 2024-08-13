namespace Exercise1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwoNewFieldsMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ReviewCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "ReviewerFirstName", c => c.String());
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "ReviewerFirstName");
            DropColumn("dbo.Reviews", "ReviewCreated");
           

        }
    }
}

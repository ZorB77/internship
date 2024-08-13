namespace Exercise1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedFieldMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}

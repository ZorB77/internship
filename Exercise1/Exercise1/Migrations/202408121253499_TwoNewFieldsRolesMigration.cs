namespace Exercise1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwoNewFieldsRolesMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "RoleDescription", c => c.String());
            AddColumn("dbo.Roles", "MovieAppereances", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "MovieAppereances");
            DropColumn("dbo.Roles", "RoleDescription");
        }
    }
}

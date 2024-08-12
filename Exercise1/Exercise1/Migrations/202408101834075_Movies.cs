namespace Exercise1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Movies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "PersonID", "dbo.Roles");
            DropIndex("dbo.People", new[] { "PersonID" });
            DropPrimaryKey("dbo.Roles");
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.Roles", "RoleID", c => c.Int(nullable: false));
            AlterColumn("dbo.People", "PersonID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Roles", "RoleID");
            AddPrimaryKey("dbo.People", "PersonID");
            CreateIndex("dbo.Roles", "RoleID");
            AddForeignKey("dbo.Roles", "RoleID", "dbo.People", "PersonID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "RoleID", "dbo.People");
            DropIndex("dbo.Roles", new[] { "RoleID" });
            DropPrimaryKey("dbo.People");
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.People", "PersonID", c => c.Int(nullable: false));
            AlterColumn("dbo.Roles", "RoleID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "PersonID");
            AddPrimaryKey("dbo.Roles", "RoleID");
            CreateIndex("dbo.People", "PersonID");
            AddForeignKey("dbo.People", "PersonID", "dbo.Roles", "RoleID");
        }
    }
}

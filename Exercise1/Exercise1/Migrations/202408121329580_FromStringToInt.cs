namespace Exercise1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FromStringToInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Studios", "StudioYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Studios", "StudioYear", c => c.String());
        }
    }
}

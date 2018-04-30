namespace DatabaseTest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "CreatedAt");
            DropColumn("dbo.Comments", "CreatedAt");
        }
    }
}

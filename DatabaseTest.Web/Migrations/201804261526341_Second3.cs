namespace DatabaseTest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "LastModifiedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Posts", "LastModifiedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "LastModifiedAt");
            DropColumn("dbo.Comments", "LastModifiedAt");
        }
    }
}

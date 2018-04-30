namespace DatabaseTest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}

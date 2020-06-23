namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "TagList", c => c.String());
            AddColumn("dbo.Question", "ImageUrl", c => c.String());
            AddColumn("dbo.User", "ImageUrl", c => c.String());
            DropColumn("dbo.Question", "Tag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Question", "Tag", c => c.String());
            DropColumn("dbo.User", "ImageUrl");
            DropColumn("dbo.Question", "ImageUrl");
            DropColumn("dbo.Question", "TagList");
        }
    }
}

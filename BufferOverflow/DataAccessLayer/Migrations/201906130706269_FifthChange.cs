namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LikeDislike", "Like", c => c.Int(nullable: false));
            AddColumn("dbo.LikeDislike", "Dislike", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LikeDislike", "Dislike");
            DropColumn("dbo.LikeDislike", "Like");
        }
    }
}

namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finallllll : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LikeDislike", "Vote", c => c.Int(nullable: false));
            DropColumn("dbo.LikeDislike", "Like");
            DropColumn("dbo.LikeDislike", "Dislike");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LikeDislike", "Dislike", c => c.Int(nullable: false));
            AddColumn("dbo.LikeDislike", "Like", c => c.Int(nullable: false));
            DropColumn("dbo.LikeDislike", "Vote");
        }
    }
}

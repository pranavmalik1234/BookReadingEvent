namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdChange : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LikeDislike",
                c => new
                {
                    LikeDislikeId = c.Int(nullable: false, identity: true),
                    AnswerId = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.LikeDislikeId);

        }
        
        public override void Down()
        {
            DropTable("dbo.LikeDislike");
        }
    }
}

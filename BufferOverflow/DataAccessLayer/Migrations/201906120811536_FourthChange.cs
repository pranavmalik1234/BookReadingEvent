namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answer", "Vote", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answer", "Vote");
        }
    }
}

namespace RecipeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yyy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "image", c => c.String());
            DropColumn("dbo.Recipe", "video");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipe", "video", c => c.String());
            DropColumn("dbo.Recipe", "image");
        }
    }
}

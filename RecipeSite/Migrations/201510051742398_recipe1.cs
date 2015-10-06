namespace RecipeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recipe1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        imageUrl = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Recipes", "video", c => c.String());
            AlterColumn("dbo.Recipes", "title", c => c.String());
            AlterColumn("dbo.Recipes", "content", c => c.String());
            DropColumn("dbo.Users", "MyProperty");
            DropTable("dbo.Ingredients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        amount = c.Double(nullable: false),
                        amountType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "MyProperty", c => c.Int(nullable: false));
            AlterColumn("dbo.Recipes", "content", c => c.String(nullable: false));
            AlterColumn("dbo.Recipes", "title", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Recipes", "video");
            DropTable("dbo.Categories");
        }
    }
}

namespace RecipeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init41 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorization",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categorization", "RecipeId", "dbo.Recipe");
            DropForeignKey("dbo.Categorization", "CategoryId", "dbo.Category");
            DropIndex("dbo.Categorization", new[] { "RecipeId" });
            DropIndex("dbo.Categorization", new[] { "CategoryId" });
            DropTable("dbo.Categorization");
        }
    }
}

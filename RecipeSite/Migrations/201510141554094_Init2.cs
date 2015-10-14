namespace RecipeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Recipe_ID", "dbo.Recipe");
            DropIndex("dbo.Category", new[] { "Recipe_ID" });
            CreateTable(
                "dbo.RecipeCategory",
                c => new
                    {
                        Recipe_ID = c.Int(nullable: false),
                        Category_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_ID, t.Category_ID })
                .ForeignKey("dbo.Recipe", t => t.Recipe_ID, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Recipe_ID)
                .Index(t => t.Category_ID);
            
            DropColumn("dbo.Category", "Recipe_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Recipe_ID", c => c.Int());
            DropForeignKey("dbo.RecipeCategory", "Category_ID", "dbo.Category");
            DropForeignKey("dbo.RecipeCategory", "Recipe_ID", "dbo.Recipe");
            DropIndex("dbo.RecipeCategory", new[] { "Category_ID" });
            DropIndex("dbo.RecipeCategory", new[] { "Recipe_ID" });
            DropTable("dbo.RecipeCategory");
            CreateIndex("dbo.Category", "Recipe_ID");
            AddForeignKey("dbo.Category", "Recipe_ID", "dbo.Recipe", "ID");
        }
    }
}

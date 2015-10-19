namespace RecipeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipe", "userId", "dbo.AspNetUsers");
            DropIndex("dbo.Recipe", new[] { "userId" });
            AlterColumn("dbo.Category", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Recipe", "userId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Recipe", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Recipe", "content", c => c.String(nullable: false));
            CreateIndex("dbo.Recipe", "userId");
            AddForeignKey("dbo.Recipe", "userId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "userId", "dbo.AspNetUsers");
            DropIndex("dbo.Recipe", new[] { "userId" });
            AlterColumn("dbo.Recipe", "content", c => c.String());
            AlterColumn("dbo.Recipe", "title", c => c.String());
            AlterColumn("dbo.Recipe", "userId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Category", "name", c => c.String());
            CreateIndex("dbo.Recipe", "userId");
            AddForeignKey("dbo.Recipe", "userId", "dbo.AspNetUsers", "Id");
        }
    }
}

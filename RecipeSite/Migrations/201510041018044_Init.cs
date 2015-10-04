namespace RecipeSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(nullable: false, maxLength: 15),
                        lastName = c.String(nullable: false, maxLength: 15),
                        birthDate = c.DateTime(nullable: false),
                        country = c.String(maxLength: 15),
                        city = c.String(maxLength: 15),
                        address = c.String(maxLength: 40),
                        email = c.String(nullable: false),
                        MyProperty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}

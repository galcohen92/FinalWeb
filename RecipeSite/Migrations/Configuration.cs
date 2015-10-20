namespace RecipeSite.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RecipeSite.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RecipeSite.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RecipeSite.DAL.ApplicationDbContext context)
        {
            //-----------Insert roles------------
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            if (!context.Roles.Any(r => r.Name == "Admins"))
            {               
                var role = new IdentityRole { Name = "Admins" };
            roleManager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Users"))
            {
                var role = new IdentityRole { Name = "Users" };

                roleManager.Create(role);
            }


            //-----------Insert users------------
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var user = new ApplicationUser { UserName = "admin" };
                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, "Admins");
            }
            if (!context.Users.Any(u => u.UserName == "gal"))
            {
                var user1 = new ApplicationUser { UserName = "gal", Email = "gal@gmail.com" };
                userManager.Create(user1, "123456");
                userManager.AddToRole(user1.Id, "Users");
            }
            if (!context.Users.Any(u => u.UserName == "yarden"))
            {
                var user2 = new ApplicationUser { UserName = "yarden", Email = "yarden@gmail.com" };
                userManager.Create(user2, "123456");
                userManager.AddToRole(user2.Id, "Users");
            }
            if (!context.Users.Any(u => u.UserName == "adi"))
            {
                var user3 = new ApplicationUser { UserName = "adi", Email = "adi@gmail.com" };
                userManager.Create(user3, "123456");
                userManager.AddToRole(user3.Id, "Users");
            }
            if (!context.Users.Any(u => u.UserName == "gabi"))
            {
                var user4 = new ApplicationUser { UserName = "gabi", Email = "gabi@gmail.com" };
                userManager.Create(user4, "123456");
                userManager.AddToRole(user4.Id, "Users");
            }
            if (!context.Users.Any(u => u.UserName == "moshe"))
            {
                var user5 = new ApplicationUser { UserName = "moshe", Email = "moshe@gmail.com" };
                userManager.Create(user5, "123456");
                userManager.AddToRole(user5.Id, "Users");
            }
            if (!context.Users.Any(u => u.UserName == "yoseff"))
            {
                var user6 = new ApplicationUser { UserName = "yoseff", Email = "yoseff@gmail.com" };
                userManager.Create(user6, "123456");
                userManager.AddToRole(user6.Id, "Users");
            }       

            //-----------Insert categories------------
       
            context.Categories.AddOrUpdate(x => x.ID,
       new Category() { ID = 1, name = "Meat", imageUrl = "/Upload/Images/Categories/meat.jpg" },
        new Category() { ID = 2, name = "Dessert", imageUrl = "/Upload/Images/Categories/dessert.jpg" },
         new Category() { ID = 3, name = "Pasta", imageUrl = "/Upload/Images/Categories/pasta.jpg" },
         new Category() { ID = 4, name = "Bread", imageUrl = "/Upload/Images/Categories/bread.jpg" },
         new Category() { ID = 5, name = "Diet", imageUrl = "/Upload/Images/Categories/diet.jpg" },
         new Category() { ID = 6, name = "Fish", imageUrl = "/Upload/Images/Categories/fish.jpg" },
         new Category() { ID = 7, name = "Slow Cooker", imageUrl = "/Upload/Images/Categories/slow_cooker.jpg" },
         new Category() { ID = 8, name = "Soup", imageUrl = "/Upload/Images/Categories/soup.jpg" },
         new Category() { ID = 9, name = "Vegetarian", imageUrl = "/Upload/Images/Categories/vegeterian.jpg" },
         new Category() { ID = 10, name = "Chicken", imageUrl = "/Upload/Images/Categories/chicken.jpg" },
         new Category() { ID = 11, name = "Gluten Free", imageUrl = "/Upload/Images/Categories/gluten_free.jpg" });

            //-----------Insert recipes------------
            //           context.Categories.AddOrUpdate(x => x.ID,
            //new Category() { ID = 1, name = "Meat", imageUrl = "/Upload/Images/Categories/meat.jpg" },
            // new Category() { ID = 2, name = "Dessert", imageUrl = "/Upload/Images/Categories/dessert.jpg" },
            //  new Category() { ID = 3, name = "Pasta", imageUrl = "/Upload/Images/Categories/pasta.jpg" },
            //  new Category() { ID = 4, name = "Bread", imageUrl = "/Upload/Images/Categories/bread.jpg" },
            //  new Category() { ID = 5, name = "Diet", imageUrl = "/Upload/Images/Categories/diet.jpg" },
            //  new Category() { ID = 6, name = "Fish", imageUrl = "/Upload/Images/Categories/fish.jpg" },
            //  new Category() { ID = 7, name = "Slow Cooker", imageUrl = "/Upload/Images/Categories/slow_cooker.jpg" },
            //  new Category() { ID = 8, name = "Soup", imageUrl = "/Upload/Images/Categories/soup.jpg" },
            //  new Category() { ID = 9, name = "Vegetarian", imageUrl = "/Upload/Images/Categories/vegeterian.jpg" },
            //  new Category() { ID = 10, name = "Chicken", imageUrl = "/Upload/Images/Categories/chicken.jpg" },
            //  new Category() { ID = 11, name = "Gluten Free", imageUrl = "/Upload/Images/Categories/gluten_free.jpg" });

            //-----------Insert ingredients------------
            //    context.Categories.AddOrUpdate(x => x.ID,
            //new Ingredient() { ID = 1, Name = "Egg", Fat="",Calories="",
            //new Ingredient() { ID = 2, Name= "Bread"
            //new Ingredient() { ID = 3, Name= "Water
            //new Ingredient() { ID = 4, Name= "Brea
            //new Ingredient() { ID = 5, Name= "Diet
            //new Ingredient() { ID = 6, Name= "Fish
            //new Ingredient() { ID = 7, Name= "Slow
            //new Ingredient() { ID = 8, Name= "Soup
            //new Ingredient() { ID = 9, Name= "Vege
            //new Ingredient() { ID = 10,Name = "Chi
            //new Ingredient() { ID = 11,Name = "Glu

            context.SaveChanges();
        }
    }
}
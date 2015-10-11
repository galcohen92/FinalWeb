using Microsoft.AspNet.Identity.EntityFramework;
using RecipeSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RecipeSite.DAL
{
     
    //public class ApplicationDbContext : DbContext
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<RecipeSite.Models.Recipe> Recipes { get; set; }
        //public System.Data.Entity.DbSet<RecipeSite.Models.Ingredient> Ingredients { get; set; }
       // public System.Data.Entity.DbSet<RecipeSite.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<RecipeSite.Models.Category> Categories { get; set; }
        public System.Data.Entity.DbSet<RecipeSite.Models.Categorization> Categorizations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ApplicationUser>().HasKey<string>(a => a.Id);
            //modelBuilder.Entity<Recipe>().HasKey(r => r.ID).HasMany(r => r.categories);
            //modelBuilder.Entity<Category>().HasKey(c => c.ID);
        //    modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
        //    modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }

          public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
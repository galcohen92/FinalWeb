﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    //public class RecipeSiteContext : IdentityDbContext<ApplicationUser>
    public class RecipeSiteContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public RecipeSiteContext() : base("name=RecipeSiteContext")
        {
        }

        public System.Data.Entity.DbSet<RecipeSite.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<RecipeSite.Models.Recipe> Recipes { get; set; }
        //public System.Data.Entity.DbSet<RecipeSite.Models.Ingredient> Ingredients { get; set; }
        public System.Data.Entity.DbSet<RecipeSite.Models.Category> Categories { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    base.OnModelCreating(modelBuilder);


        //    modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
        //    modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        //}

        //public static RecipeSiteContext Create()
        //{
        //    return new RecipeSiteContext();
        //}

    }
}

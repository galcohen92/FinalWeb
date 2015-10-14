using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class Category
    {
        public int ID { get; set; }

        public String name { get; set; }

        public String imageUrl { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public Category(){}

        public Category(String name, String url)
        {
            this.imageUrl = url;
            this.name = name;
        }
    }
}
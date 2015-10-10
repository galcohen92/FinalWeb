using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class Categorization
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public int RecipeId { get; set; }



        public virtual Category category { get; set; }
        public virtual Recipe recipe { get; set; }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{


    public class Recipe
    {
        public int ID { get; set; }

        public int userId { get; set; }



        public String title { get; set; }


        public String content { get; set; }
        public String video { get; set; }


        public int likeAmount { get; set; }


        //public IEnumerable<Ingredient> ingredients { get; set; }


        public IEnumerable<Category> categories { get; set; }

        public virtual ApplicationUser author { get; set; }

        public Recipe()
        {

        }
    }
}
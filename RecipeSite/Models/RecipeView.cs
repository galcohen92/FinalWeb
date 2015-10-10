using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class RecipeView
    {

        [Required]
        [StringLength(30)]
        public String title { get; set; }

        [Required]
        public String content { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase video { get; set; }

        [Required]
        public int likeAmount { get; set; }

        //[Required]
        //public IEnumerable<Ingredient> ingredients { get; set; }

        [Required]
        public IEnumerable<Category> categories { get; set; }

        public virtual ApplicationUser author { get; set; }
    }
}
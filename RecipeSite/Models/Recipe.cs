using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class Recipe
    {
        public int ID { get; set; }

        [Required]
        public string userId { get; set; }

        [Required]
        public String title { get; set; }

        [Required]
        public String content { get; set; }

        public String image { get; set; }

        public int likeAmount { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        [ForeignKey("userId")]
        public virtual ApplicationUser author { get; set; }

        public Recipe(){}
    }
}
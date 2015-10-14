using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class Categorization
    {
        [Key]
        public int ID { get; set; }

        public int CategoryId { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }

        public Categorization(){}
    }
}
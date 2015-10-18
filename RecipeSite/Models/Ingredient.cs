using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    //    public enum AmountType
    //    {
    //        KILOGRAM,
    //        GRAM,
    //        LITER,
    //        BOTTLE,
    //        BOX,
    //        KORT,
    //        SPOON
    //    }

    public class Ingredient
    {
        public int ID { get; set; }

        [Required]
        public string userId { get; set; }


        [Required]
        public String Name { get; set; }

        [Required]
        [Range(0, 999999)]
        public decimal Calories { get; set; }

        [Required]
        public decimal Fat { get; set; }

        public Ingredient()
        {
            Name = "";
            Calories = 0.0M;
            Fat = 0.0M;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public enum AmountType
	{
        KILOGRAM,
        GRAM,
        LITER,
        BOTTLE,
        BOX,
        KORT,
        SPOON
	}

    public class Ingredient
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public String name { get; set; }

        [Required]
        [Range(0, 999999)]
        public Double amount { get; set; }

        [Required]
        public AmountType amountType { get; set; }
    }
}
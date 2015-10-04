using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public enum CATEGORY
    {
        DESSERT,
        SALAD,
        CHICKEN,
        HEALTHY,
        EVENTS,
        MAIN_DISH,
        DIABETIC,
        LACTOSE,
        CELIAC,
        VEGETARIAN
    }

    public class Recipe
    {
        public int ID { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        [StringLength(30)]
        public String title { get; set; }

        [Required]
        public String content { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase video { get; set; }

        [Required]
        public int likeAmount { get; set; }

        [Required]
        public IEnumerable<Ingredient> ingredients { get; set; }

        [Required]
        public IEnumerable<CATEGORY> categories { get; set; }

        public virtual User author { get; set; }
    }
}
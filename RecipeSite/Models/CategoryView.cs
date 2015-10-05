using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class CategoryView
    {
        [Required]
        public String name { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase image { get; set; }
    }
}
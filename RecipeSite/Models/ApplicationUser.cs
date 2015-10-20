using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RecipeSite.Models
{
    public class ApplicationUser : IdentityUser 
    {
        public DateTime BirthDate { get; set; }

        public String Country { get; set; }

        public String City { get; set; }

        public String Address { get; set; }

        public virtual List<Recipe> UserRecipes { get; set; }

        public ApplicationUser()
        {
            BirthDate = DateTime.Now;
        }        
    }
}
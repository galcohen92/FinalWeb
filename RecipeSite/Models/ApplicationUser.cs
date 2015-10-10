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
        //public int ID { get; set; }

        //[Display(Name = "first name")]
        //[Required]
        //[StringLength(15)]
        public String FirstName { get; set; }

        //[Display(Name = "last name")]
        //[Required]
        //[StringLength(15)]
        public String LastName { get; set; }

        //[Display(Name = "birthday")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        //[StringLength(15)]
        public String Country { get; set; }

        //[StringLength(15)]
        public String City { get; set; }

        //[StringLength(40)] 
        public String Address { get; set; }

        //[DataType(DataType.EmailAddress)]
        //[Required]
        //public String email { get; set; }

        public virtual List<Recipe> UserRecipes { get; set; }

        public ApplicationUser()
        {

        }        
    }
}
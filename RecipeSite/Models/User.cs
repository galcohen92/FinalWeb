using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RecipeSite.Models
{
    public class User
    {
        public int ID { get; set; }

        [Display(Name = "first name")]
        [Required]
        [StringLength(15)]
        public String firstName { get; set; }

        [Display(Name = "last name")]
        [Required]
        [StringLength(15)]
        public String lastName { get; set; }

        [Display(Name = "birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime birthDate { get; set; }

        [StringLength(15)]
        public String country { get; set; }

        [StringLength(15)]
        public String city { get; set; }

        [StringLength(40)] 
        public String address { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public String email { get; set; }

        public int MyProperty { get; set; }
        
    }
}
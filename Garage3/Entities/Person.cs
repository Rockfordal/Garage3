using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage3.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(8), MaxLength(12)]
        public string SSN { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Firstname cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]

        [Required]
        [StringLength(50, ErrorMessage = "Lastname cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
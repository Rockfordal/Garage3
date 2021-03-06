﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garage3.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "RegNr måste anges")]
        [MinLength(6, ErrorMessage = "RegNr måste vara minst 6 tecken långt")]
        [MaxLength(10, ErrorMessage = "RegNr får inte vara länge än 10 tecken")]
        [RegularExpression("^[A-Z0-9- ]{5,10}$", ErrorMessage = "RegNr måste bestå av siffror och bokstäver samt -")] 
        public string RegNr { get; set; }

        [Required]
        public string Color { get; set; }

        [Required, Range(0, 100)]
        public int NumberOfWheels { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public virtual VehicleType VehicleType { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime EnrollmentDate { get; set; }

        public virtual Owner Owner { get; set; }
    }
}
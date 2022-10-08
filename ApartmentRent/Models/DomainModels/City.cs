using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApartmentRent.Models
{
    public class City
    {
       [Key]
        public int CityId { get; set; }
        public Guid Guid { get; set; }
        [Required(ErrorMessage = "Please enter the city name.")]
        [StringLength(250)]
        public string Name { get; set; }
        

        public  ICollection<Apartment> Apartment { get; set; }

    }
}

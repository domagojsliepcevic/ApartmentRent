using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApartmentRent.Models
{
    public class ApartmentOwner
    {
        [Key]
        public int ApartmentOwnerId { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public string Name { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public  ICollection<Apartment> Apartment { get; set; }
    }
}

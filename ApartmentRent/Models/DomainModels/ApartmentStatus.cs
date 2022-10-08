using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApartmentRent.Models
{
    public class ApartmentStatus
    {
        [Key]
        public int StatusId { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }

        public  ICollection<Apartment> Apartment { get; set; }
    }
}

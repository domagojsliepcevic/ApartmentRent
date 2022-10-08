using System;

namespace ApartmentRent.Models
{
    public class TaggedApartment
    {
    
        public Guid Guid { get; set; }
        public int ApartmentId { get; set; }
        public int TagId { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual Tag Tag { get; set; }
    }
}

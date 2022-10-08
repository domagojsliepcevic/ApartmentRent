using System;

namespace ApartmentRent.Models
{
    public class ApartmentReservation
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ApartmentId { get; set; }
        
        public decimal TotalPrice { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string UserAddress { get; set; }

        public  Apartment Apartment { get; set; }
        public  User User { get; set; }
    }
}

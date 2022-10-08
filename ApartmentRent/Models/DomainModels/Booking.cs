using System;

namespace ApartmentRent.Models.DomainModels
{
    public class Booking
    {
        public int BookingId { get; set; }
        public Apartment BookedApartment { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public string CustomerFName { get; set; }
        public string CustomerLName { get; set; }
        public string CreditCardNumber { get; set; }
        public TimeSpan BookingDuration { get { return BookingEnd - BookingStart; } }
        public Double Price { get { return (int)BookingDuration.Days * BookedApartment.Price; } }
       

    }
}

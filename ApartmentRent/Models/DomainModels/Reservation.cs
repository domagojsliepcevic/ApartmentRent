using System;

namespace ApartmentRent.Models.DomainModels
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public Apartment BookedApartment { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public string CustomerFName { get; set; }
        public string CustomerLName { get; set; }
        public string CreditCardNumber { get; set; }
        public TimeSpan ReservationDuration { get { return ReservationEnd - ReservationStart; } }
        public Double Price { get { return (int)ReservationDuration.Days * BookedApartment.Price; } }
       

    }
}

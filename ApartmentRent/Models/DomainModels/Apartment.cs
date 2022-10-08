using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApartmentRent.Models
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public int OwnerId { get; set; }
        public int StatusId { get; set; }
        public int CityId { get; set; }

        public int ImageId { get; set; }

        [Required(ErrorMessage = "Please enter an address.")]
        [StringLength(250)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a localized apartment name.")]
        [StringLength(250)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a globalized apartment name.")]
        [StringLength(250)]
        public string NameEng { get; set; }
        [Range(0.0, 1000000.0, ErrorMessage = "Price must be more than 0.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please enter the maximum occupancy for adults.")]
        [Range(0, 5, ErrorMessage = "Must be more then 0 and less then 5.")]
        public int MaxAdults { get; set; }
        [Required(ErrorMessage = "Please enter the maximum occupancy for children.")]
        [Range(0, 5, ErrorMessage = "Must be more then 0 and less then 5.")]
        public int MaxChildren { get; set; }
        [Required(ErrorMessage = "Please enter the amount of rooms located in the apartment.")]
        [Range(0, 10, ErrorMessage = "Must be more then 0 and less then 10.")]
        public int TotalRooms { get; set; }
        public string BeachDistance { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescritpion { get; set; }



        public ApartmentProfilePicture ApartmentProfilePicture { get; set; }
        public City City { get; set; }
        public ApartmentOwner Owner { get; set; }
        public ApartmentStatus Status { get; set; }
        public ICollection<ApartmentAlbum> ApartmentAlbum { get; set; }
        public ICollection<TaggedApartment> TaggedApartment { get; set; }
    }
}

using System;

namespace ApartmentRent.Models
{
    public class ApartmentAlbum
    {
        public Guid Guid { get; set; }
        public int ApartmentId { get; set; }
        public int ImageId { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual ApartmentPicture Picture { get; set; }
    }
}

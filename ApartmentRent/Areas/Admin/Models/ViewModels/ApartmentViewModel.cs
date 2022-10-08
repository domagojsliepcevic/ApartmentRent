using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApartmentRent.Models
{
    public class ApartmentViewModel
    {
        public Apartment Apartment { get; set; }

        public IEnumerable<ApartmentProfilePicture> ApartmentProfilePictures { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<ApartmentOwner> Owners { get; set; }
        public IEnumerable<ApartmentStatus> Statuses { get; set; }

        public IEnumerable<Tag> Tags { get; set; }  

        public IEnumerable<ApartmentPicture> Picture { get; set; }

        public int[] SelectedTags { get; set; }
        public int[] SelectedPictures { get; set; }
    }
      
}

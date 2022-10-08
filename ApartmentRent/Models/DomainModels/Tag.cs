using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApartmentRent.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public Guid Guid { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public int TypeId { get; set; }
        [Required(ErrorMessage = "Please enter a localized tag name.")]
        [StringLength(250)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a globalized tag name.")]
        [StringLength(250)]
        public string NameEng { get; set; }

        public  TagType Type { get; set; }
        public  ICollection<TaggedApartment> TaggedApartment { get; set; }
    }
}

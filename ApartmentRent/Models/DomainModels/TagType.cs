using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApartmentRent.Models
{
    public class TagType
    {
        [Key]
        public int TypeId { get; set; }
        public Guid Guid { get; set; }
        [Required(ErrorMessage = "Please enter a localized tag type name.")]
        [StringLength(250)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a globalized tag type name.")]
        [StringLength(250)]
        public string NameEng { get; set; }
        public  ICollection<Tag> Tag { get; set; }
    }
}

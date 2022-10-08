using System.Collections;
using System.Collections.Generic;

namespace ApartmentRent.Models
{
    public class TagViewModel
    {
        public Tag Tag { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<TagType> TagType { get; set; }

    }
}

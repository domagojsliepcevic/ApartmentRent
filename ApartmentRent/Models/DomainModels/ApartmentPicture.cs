using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentRent.Models
{
    //File : /Models/DomainModels/ApartmentPicture.cs
    public class ApartmentPicture
    {
        [Key]
        public int ImageId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ApartmentName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        public ICollection<ApartmentAlbum> Album { get; set; }
    }
}

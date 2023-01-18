using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;

namespace ApartmentRent.Models
{
    public class ApartmentReview
    {
        [Key]
        public int ApartmentReviewId { get; set; }



        public string ReviewText { get; set; }

        public DateTime ReviewTime { get; set; }

        public int ApartmentId { get; set; }

        [ForeignKey(nameof(ApartmentId))]
        public virtual Apartment Apartment { get; set; }


        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

    }
}

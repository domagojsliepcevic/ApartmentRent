using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentRent.Models
{
    public class TaggedApartmentConfig : IEntityTypeConfiguration<TaggedApartment>
    {
        public void Configure(EntityTypeBuilder<TaggedApartment> entity)
        {
            // TaggedApartment: set primary key 
            entity.HasKey(ta => new { ta.ApartmentId, ta.TagId });

            // TaggedApartment: set foreign keys 
            entity.HasOne(ta => ta.Apartment)
                .WithMany(a => a.TaggedApartment)
                .HasForeignKey(ta => ta.ApartmentId);
            entity.HasOne(ba => ba.Tag)
                .WithMany(t => t.TaggedApartment)
                .HasForeignKey(ta => ta.TagId);
            //TaggedApartment:GUID
            entity.Property(ta => ta.Guid).HasDefaultValueSql("(newid())");
        }
    }
}

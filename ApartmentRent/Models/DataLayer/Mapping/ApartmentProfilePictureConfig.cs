using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentRent.Models
{
    public class ApartmentProfilePictureConfig : IEntityTypeConfiguration<ApartmentProfilePicture>
    {
        public void Configure(EntityTypeBuilder<ApartmentProfilePicture> entity)
        {
            entity.HasKey(e=>e.ImageId);

            entity.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(250);

            entity.Property(e => e.ApartmentName)
               .IsRequired()
               .HasMaxLength(250);
        }
    }
}

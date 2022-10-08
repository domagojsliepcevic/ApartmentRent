using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentRent.Models
{
    public class ApartmentAlbumConfig : IEntityTypeConfiguration<ApartmentAlbum>
    {
        public void Configure(EntityTypeBuilder<ApartmentAlbum> entity)
        {
            // ApartmentAlbum: set primary key 
            entity.HasKey(aa => new { aa.ApartmentId, aa.ImageId });

            // ApartmentAlbum: set foreign keys 
            entity.HasOne(aa => aa.Apartment)
                .WithMany(a => a.ApartmentAlbum)
                .HasForeignKey(aa => aa.ApartmentId);
            entity.HasOne(aa => aa.Picture)
                .WithMany(ap => ap.Album)
                .HasForeignKey(aa => aa.ImageId);
            //ApartmentAlbum:GUID
            entity.Property(ta => ta.Guid).HasDefaultValueSql("(newid())");
        }
    }
}

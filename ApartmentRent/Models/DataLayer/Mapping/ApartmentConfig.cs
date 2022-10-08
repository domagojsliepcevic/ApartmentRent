using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentRent.Models
{
    public class ApartmentConfig : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> entity)
        {
            entity.Property(e => e.Address).HasMaxLength(250);

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.NameEng)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(a => a.ApartmentProfilePicture)
                .WithMany(app => app.Apartment)
                .HasForeignKey(a => a.ImageId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Apartment_ApartmentProfilePicture");

            entity.HasOne(d => d.City)
                .WithMany(p => p.Apartment)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Apartment_City");

            entity.HasOne(d => d.Owner)
                .WithMany(p => p.Apartment)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apartment_ApartmentOwner");

            entity.HasOne(d => d.Status)
                .WithMany(p => p.Apartment)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apartment_ApartmentStatus");

        }
    }
}

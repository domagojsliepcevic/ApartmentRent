using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentRent.Models
{
    public class ApartmentStatusConfig : IEntityTypeConfiguration<ApartmentStatus>
    {
        public void Configure(EntityTypeBuilder<ApartmentStatus> entity)
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.NameEng)
                .IsRequired()
                .HasMaxLength(250);

            entity.HasData(
                new ApartmentStatus { StatusId=1,Name="Slobodno",NameEng="Free"},
                new ApartmentStatus {StatusId=2,Name="Zauzeto", NameEng="Booked" },
                new ApartmentStatus { StatusId=3,Name="Rezervirano",NameEng="Reserved"});

        }
    }
}

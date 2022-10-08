using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ApartmentRent.Models
{
    public class ApartmentOwnerConfig : IEntityTypeConfiguration<ApartmentOwner>
    {
        public void Configure(EntityTypeBuilder<ApartmentOwner> entity)
        {
            entity.HasKey(e=>e.ApartmentOwnerId);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(250);

            entity.HasData(
                new ApartmentOwner { ApartmentOwnerId=1, Name ="Domagoj Sliepcevic",Email="domagoj.sliepcevic@racunarstvo.hr" });
        }
    }
}

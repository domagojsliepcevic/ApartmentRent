using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ApartmentRent.Models
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

            entity.HasData(
                new City { CityId=1,Name = "Vinkovci" },
                new City { CityId=2,Name="Zagreb"},
                new City { CityId=3,Name="Split"}
                );
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentRent.Models
{
    public class TagTypeConfig : IEntityTypeConfiguration<TagType>
    {
        public void Configure(EntityTypeBuilder<TagType> entity)
        {
            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.NameEng)
                .IsRequired()
                .HasMaxLength(250);

            entity.HasData(
                new TagType { TypeId=1,Name="Aparati",NameEng="Devices"},
                new TagType { TypeId=2,Name="Podrucja",NameEng="Areas"},
                new TagType { TypeId=3,Name="Ostalo",NameEng="Other"});
        }
    }
}

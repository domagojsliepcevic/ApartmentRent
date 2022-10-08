using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentRent.Models
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> entity)
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.NameEng).HasMaxLength(250);

            entity.HasOne(d => d.Type)
                .WithMany(p => p.Tag)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Tag_TagType");

            entity.HasData(
                new Tag { TagId=1,TypeId=1,Name="Kafe aparat",NameEng="Coffee maker"},
                new Tag { TagId=2,TypeId=1,Name= "Perilica sudja", NameEng= "Dishwasher" },
                new Tag { TagId=3,TypeId=2,Name= "Balkon", NameEng= "Balcony" },
                new Tag { TagId=4,TypeId=2,Name= "Kupaonica", NameEng= "Bathroom" },
                new Tag { TagId=5,TypeId=2,Name= "Kada", NameEng= "Bathtub" },
                new Tag { TagId=6,TypeId=2,Name= "Bide", NameEng= "Bidet" }
                );
        }
    }
}

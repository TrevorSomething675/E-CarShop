using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using E_CarShop.DataBase.Entities;

namespace E_CarShop.DataBase.Configurations
{
    internal sealed class ImageEntityConfiguration : IEntityTypeConfiguration<ImageEntity>
    {
        public void Configure(EntityTypeBuilder<ImageEntity> builder)
        {
            builder.ToTable("Images");

            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Car)
                .WithMany(c => c.Images)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
        }
    }
}
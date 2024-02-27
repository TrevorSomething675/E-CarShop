using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using E_CarShop.DataBase.Entities;

namespace E_CarShop.DataBase.Configurations
{
    internal sealed class CarEntityConfiguration : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Users)
                .WithMany(u => u.Cars)
                .UsingEntity("UserCar");
        }
    }
}
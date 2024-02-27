using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using E_CarShop.DataBase.Entities;

namespace E_CarShop.DataBase.Configurations
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Users)
                .WithOne(u => u.Role);

            builder.Property(r => r.Name)
                .IsRequired();
        }
    }
}
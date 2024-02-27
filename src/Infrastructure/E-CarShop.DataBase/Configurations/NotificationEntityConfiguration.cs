using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using E_CarShop.DataBase.Entities;

namespace E_CarShop.DataBase.Configurations
{
    public class NotificationEntityConfiguration : IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(n => n.Id);

            builder.HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.Property(n => n.Header)
                .IsRequired();
            builder.Property(n => n.Description)
                .IsRequired();
        }
    }
}
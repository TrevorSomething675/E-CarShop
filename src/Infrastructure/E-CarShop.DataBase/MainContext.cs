using E_CarShop.Core.ConfigurationModels;
using E_CarShop.DataBase.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using E_CarShop.DataBase.Entities;

namespace E_CarShop.DataBase
{
    public class MainContext(IOptions<DataBaseOptions> dataBaseOptions) : DbContext
    {
        private readonly DataBaseOptions _dataBaseOptions = dataBaseOptions.Value;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_dataBaseOptions.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ImageEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<CarEntity> Cars { get; set; }
        public DbSet<ImageEntity> Images { get; set; }
        public DbSet<NotificationEntity> Notification { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}
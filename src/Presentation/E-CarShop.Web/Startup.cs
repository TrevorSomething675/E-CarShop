﻿using E_CarShop.Application.Repositories;
using E_CarShop.Core.ConfigurationModels;
using E_CarShop.DataBase.Repositories;
using E_CarShop.Web.Configurations;
using E_CarShop.DataBase.Entities;
using E_CarShop.DataBase;
using System.Reflection;

namespace E_CarShop.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<DataBaseOptions>(configuration.GetSection(DataBaseOptions.SectionName));
            services.AddDbContextFactory<MainContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(Infrastructure.AssemblyMarker))));
            services.AddAppAutoMapper();
            services.AddControllersWithViews();
            using (var context = services.BuildServiceProvider().GetRequiredService<MainContext>())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var roles = new List<RoleEntity>
                {
                    new RoleEntity
                    {
                        Name = "User"
                    }
                };
                var brands = new List<BrandEntity>
                {
                    new BrandEntity
                    {
                        Name = "Brand-1"
                    }
                };

                context.Brands.AddRange(brands);
                context.Roles.AddRange(roles);
                context.SaveChanges();
                var cars = new List<CarEntity>
                {
                    new CarEntity
                    {
                        Name = "car-1",
                        Color = "Red",
                        IsVisible = true,
                        Description = "car-1-description",
                        Price = 1000,
                        Brand = context.Brands.FirstOrDefault(),
                        Images = new List<ImageEntity>
                        {
                            new ImageEntity
                            {
                                Name = "image-name-1",
                                Path = "path-1"
                            },
                            new ImageEntity
                            {
                                Name = "image-name-2",
                                Path = "path-2"
                            }
                        }
                    },
                    new CarEntity
                    {
                        Name = "car-2",
                        Color = "Red",
                        IsVisible = true,
                        Description = "car-2-description",
                        Price = 2000,
                        Brand = context.Brands.FirstOrDefault()
                    }
                };
                var users = new List<UserEntity>
                {
                    new UserEntity
                    {
                        Name = "user-1",
                        Email = "user@mail.ru",
                        Password = "123123123Qq",
                        Cars = context.Cars.ToList(),
                        Role = context.Roles.FirstOrDefault()
                    }
                };
                context.Users.AddRange(users);
                context.Cars.AddRange(cars);
                context.SaveChanges();
            }
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseHsts();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Cars}/{action=GetAll}");
            });
        }
    }
}
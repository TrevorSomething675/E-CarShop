using System.Reflection;
using AutoMapper;

namespace E_CarShop.Web.Configurations
{
    public static class ServiceCollectionMapperExtensions
    {
        static public IServiceCollection AddAppAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddMaps(Assembly.GetAssembly(typeof(DataBase.AssemblyMarker)));
                config.AddMaps(Assembly.GetExecutingAssembly());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
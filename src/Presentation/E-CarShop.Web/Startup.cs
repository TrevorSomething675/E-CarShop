using E_CarShop.Core.ConfigurationModels;
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
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(Infrastructure.AssemblyMarker))));
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
using E_CarShop.Core.ConfigurationModels;
using Microsoft.Extensions.Options;
using Minio;

namespace E_CarShop.Web.Configurations
{
    public static class ServiceCollectionMinioExtensions
    {
        public static IServiceCollection AddAppMinio(this IServiceCollection services)
        {
            var minioOptions = services.BuildServiceProvider().GetRequiredService<IOptions<MinioOptions>>().Value;

            services.AddMinio(config => config
                .WithEndpoint(minioOptions.StorageEndPoint)
                .WithCredentials(minioOptions.ROOT_USER, minioOptions.ROOT_PASSWORD)
                .WithSSL(false)
                .Build());

            return services;
        }
    }
}
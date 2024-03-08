using E_CarShop.Application.Services;
using Minio.DataModel.Args;
using Minio;

namespace E_CarShop.Infrastructure.Services
{
    public class MinioService(IMinioClientFactory minioClientFactory) : IMinioService
    {
        private readonly IMinioClientFactory _minioClientFactory = minioClientFactory;
        public async Task<string> GetObjectByNameAsync(string path)
        {
            string bucketName = Path.GetDirectoryName(path);
            string objectName = Path.GetFileName(path);
            byte[] data = null;
            try
            {
                using(var client = _minioClientFactory.CreateClient())
                {
                    var args = new GetObjectArgs()
                        .WithBucket(bucketName)
                        .WithObject(objectName)
                        .WithCallbackStream(async (stream) =>
                        {
                            await using (var ms = new MemoryStream())
                            {
                                stream.CopyTo(ms);
                                data = ms.ToArray();
                            }
                        });
                    await client.GetObjectAsync(args);
                    return Convert.ToBase64String(data);
                }
            }
            catch(Exception ex)
            {
                return "Error";
            }
        }
    }
}
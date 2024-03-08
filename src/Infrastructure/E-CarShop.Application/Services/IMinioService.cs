namespace E_CarShop.Application.Services
{
    public interface IMinioService
    {
        public Task<string> GetObjectByNameAsync(string path);
    }
}
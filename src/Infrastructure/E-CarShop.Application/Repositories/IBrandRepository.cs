using E_CarShop.Core.Models;

namespace E_CarShop.Application.Repositories
{
    public interface IBrandRepository
    {
        public Task<Brand> GetBrandById(int id, CancellationToken cancellationToken = default);
    }
}
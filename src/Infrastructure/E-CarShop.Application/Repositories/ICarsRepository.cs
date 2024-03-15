using E_CarShop.Core.Models;

namespace E_CarShop.Application.Repositories
{
    public interface ICarsRepository
    {
        public Task<Car> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<List<Car>> GetCarsAsync(string role, CancellationToken cancellationToken = default);
        public Task<List<Car>> GetPageCarsAsync(int pageNumber, string role, CancellationToken cancellationToken = default);
        public Task<Car> CreateAsync(Car car, CancellationToken cancellationToken = default);
        public Task<Car> UpdateAsync(Car car, CancellationToken cancellationToken = default);
        public Task<Car> DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
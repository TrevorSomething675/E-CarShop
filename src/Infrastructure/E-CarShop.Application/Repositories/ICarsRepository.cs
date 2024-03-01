using E_CarShop.Core.Models;

namespace E_CarShop.Application.Repositories
{
    public interface ICarsRepository
    {
        public Task<Car> GetByIdAsync(int id, string role, CancellationToken cancellationToken);
        public Task<List<Car>> GetCarsAsync(int pageNumber, string role, CancellationToken cancellationToken);
        public Task<Car> CreateAsync(Car car, CancellationToken cancellationToken);
        public Task<Car> UpdateAsync(Car car, CancellationToken cancellationToken);
        public Task<Car> DeleteByIdAsync(int id, CancellationToken cancellationToken);
    }
}
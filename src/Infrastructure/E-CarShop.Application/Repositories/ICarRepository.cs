using E_CarShop.Core.Models;

namespace E_CarShop.Application.Repositories
{
    public interface ICarRepository
    {
        public Task<Car> GetByIdAsync(int id);
        public Task<List<Car>> GetCarsAsync(int pageNumber = 1);
        public Task<Car> CreateAsync(Car car);
        public Task<Car> UpdateAsync(Car car);
        public Task<Car> DeleteByIdAsync(int id);
    }
}
using E_CarShop.Application.Repositories;
using E_CarShop.Core.Models;

namespace E_CarShop.DataBase.Repositories
{
    public class CarRepository : ICarRepository
    {
        public Task<Car> CreateAsync(Car car)
        {
            throw new NotImplementedException();
        }

        public Task<Car> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Car>> GetCarsAsync(int pageNumber = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Car> UpdateAsync(Car car)
        {
            throw new NotImplementedException();
        }
    }
}

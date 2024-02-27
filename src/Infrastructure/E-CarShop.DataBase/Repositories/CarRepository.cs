using E_CarShop.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using E_CarShop.Core.Models;
using AutoMapper;
using E_CarShop.DataBase.Entities;

namespace E_CarShop.DataBase.Repositories
{
    public class CarRepository(
        IDbContextFactory<MainContext> dbContextFactory,
        IMapper mapper
        ) : ICarRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<Car> CreateAsync(Car car)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var carEntity = _mapper.Map<CarEntity>(car);
                var result = context.Cars.Add(carEntity);
                await context.SaveChangesAsync();
                return _mapper.Map<Car>(result.Entity);
            }
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
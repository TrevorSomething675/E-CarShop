using E_CarShop.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using E_CarShop.DataBase.Entities;
using E_CarShop.Core.Models;
using AutoMapper;

namespace E_CarShop.DataBase.Repositories
{
    public class CarsRepository(
        IDbContextFactory<MainContext> dbContextFactory,
        IMapper mapper
        ) : ICarsRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<Car> GetByIdAsync(int id)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var carEntity = context.Cars
                    .AsNoTracking()
                    .FirstOrDefault();
                return _mapper.Map<Car>(carEntity);
            }
        }
        public async Task<List<Car>> GetCarsAsync(int pageNumber = 1)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var carEntities = await context.Cars
                    .Include(c => c.Images)
                    .AsNoTracking()
                    .Skip(8 * (pageNumber - 1))
                    .Take(8 * pageNumber)
                    .ToListAsync();
                return _mapper.Map<List<Car>>(carEntities);
            }
        }
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
        public async Task<Car> UpdateAsync(Car car)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var carEntityToUpdate = _mapper.Map<CarEntity>(car);
                var carEntity = await context.Cars
                    .Include(c => c.Images)
                    .Include(c => c.Brand)
                    .Include(c => c.Users)
                    .FirstOrDefaultAsync(c => c.Id == car.Id);
                context.Entry(carEntity).CurrentValues.SetValues(carEntityToUpdate);

                if (car.Images != null)
                    carEntity.Images = carEntityToUpdate.Images;

                var result = context.Cars.Update(carEntity);
                await context.SaveChangesAsync();

                return _mapper.Map<Car>(result.Entity);
            }
        }
        public async Task<Car> DeleteByIdAsync(int id)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var carEntity = context.Cars
                    .FirstOrDefault(c => c.Id == id);

                var result = context.Cars.Remove(carEntity);
                await context.SaveChangesAsync();

                return _mapper.Map<Car>(result.Entity);
            }
        }
    }
}
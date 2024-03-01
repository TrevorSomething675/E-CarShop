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
        public async Task<Car> GetByIdAsync(int id, string role, CancellationToken cancellationToken)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var carEntity = context.Cars
                    .AsNoTracking();

                if (role == "User")
                    await carEntity.FirstOrDefaultAsync(c => c.IsVisible, cancellationToken);
                else
                    await carEntity.FirstOrDefaultAsync(cancellationToken);
                        
                return _mapper.Map<Car>(carEntity);
            }
        }
        public async Task<List<Car>> GetCarsAsync(int pageNumber, string role, CancellationToken cancellationToken)
        {
            await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var carEntities = context.Cars
                    .Include(c => c.Images);

                if (role == "User")
                    carEntities.Where(c => c.IsVisible);

                await carEntities.AsNoTracking()
                    .Skip(8 * (pageNumber - 1))
                    .Take(8 * pageNumber)
                    .ToListAsync(cancellationToken);

                return _mapper.Map<List<Car>>(carEntities);
            }
        }
        public async Task<Car> CreateAsync(Car car, CancellationToken cancellationToken)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var carEntity = _mapper.Map<CarEntity>(car);
                var result = context.Cars.Add(carEntity);
                await context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<Car>(result.Entity);
            }
        }
        public async Task<Car> UpdateAsync(Car car, CancellationToken cancellationToken)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var carEntityToUpdate = _mapper.Map<CarEntity>(car);
                var carEntity = await context.Cars
                    .Include(c => c.Images)
                    .Include(c => c.Brand)
                    .Include(c => c.Users)
                    .FirstOrDefaultAsync(c => c.Id == car.Id, cancellationToken);
                context.Entry(carEntity).CurrentValues.SetValues(carEntityToUpdate);

                if (car.Images != null)
                    carEntity.Images = carEntityToUpdate.Images;

                var result = context.Cars.Update(carEntity);
                await context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<Car>(result.Entity);
            }
        }
        public async Task<Car> DeleteByIdAsync(int id, CancellationToken cancellationToken)
        {
            await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var carEntity = await context.Cars
                    .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

                var result = context.Cars.Remove(carEntity);
                await context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<Car>(result.Entity);
            }
        }
    }
}
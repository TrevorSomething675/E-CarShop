using E_CarShop.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using E_CarShop.DataBase.Entities;
using E_CarShop.Core.Models;
using AutoMapper;
using System.Linq;

namespace E_CarShop.DataBase.Repositories
{
    public class UserRepository(
        IMapper mapper,
        IDbContextFactory<MainContext> dbContextFactory)
        : IUserRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<User> GetByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var userEntity = context.Users
                    .Include(u => u.Cars)
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Id == id);
                return _mapper.Map<User>(userEntity);
            }
        }

        public async Task<List<User>> GetUsersAsync(int pageNumber = 1)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var userEntities = await context.Users
                    .AsNoTracking()
                    .ToListAsync();
                return _mapper.Map<List<User>>(userEntities);
            }
        }
        public async Task<User> CreateAsync(User car)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var userEntity = _mapper.Map<UserEntity>(car);
                var result = context.Users.Add(userEntity);
                await context.SaveChangesAsync();

                return _mapper.Map<User>(result.Entity);
            }
        }
        public async Task<User> UpdateAsync(User car)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var userToUpdateEntity = _mapper.Map<UserEntity>(car);
                var userEntity = context.Users
                    .AsTracking()
                    .Include(u => u.Cars)
                    .FirstOrDefault(u => u.Id == userToUpdateEntity.Id);

                context.Entry(userEntity).CurrentValues.SetValues(userToUpdateEntity);
                if(userToUpdateEntity.Cars != null)
                {
                    if(userEntity.Cars.Count() > userToUpdateEntity.Cars.Count())
                    {
                        foreach (var carEntityToUpdate in userToUpdateEntity.Cars)
                        {
                            if (!userEntity.Cars.Select(c => c.Id).Contains(carEntityToUpdate.Id))
                            {
                                userEntity.Cars.Add(carEntityToUpdate);
                            }
                        }
                    } else if(userEntity.Cars.Count() < userToUpdateEntity.Cars.Count())
                    {
                        foreach (var carEntity in userEntity.Cars)
                        {
                            if(!userToUpdateEntity.Cars.Select(c => c.Id).Contains(carEntity.Id))
                            {
                                userEntity.Cars.Remove(carEntity);
                            }
                        }
                    }
                }
                var result = context.Users.Update(userEntity);
                await context.SaveChangesAsync();

                return _mapper.Map<User>(result.Entity);
            }
        }
        public async Task<User> DeleteByIdAsync(int id)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var userEntity = context.Users
                    .FirstOrDefault(u => u.Id == id);
                var result = context.Users.Remove(userEntity);
                await context.SaveChangesAsync();

                return _mapper.Map<User>(result.Entity);
            }
        }
    }
}
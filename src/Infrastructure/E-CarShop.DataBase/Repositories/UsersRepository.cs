using E_CarShop.Application.Repositories;
using E_CarShop.Core.ConfigurationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using E_CarShop.DataBase.Entities;
using E_CarShop.Core.Models;
using AutoMapper;

namespace E_CarShop.DataBase.Repositories
{
    public class UsersRepository(
        IMapper mapper,
        IDbContextFactory<MainContext> dbContextFactory,
        IOptions<JwtAuthOptions> options
        ) : IUsersRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            await using (var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var userEntity = await context.Users
                    .Include(u => u.Cars)
                    .Include(u => u.Role)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
                return _mapper.Map<User>(userEntity); 
            }
        }
        public async Task<List<User>> GetUsersAsync(int pageNumber, CancellationToken cancellationToken = default)
        {
            await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var userEntities = await context.Users
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
                return _mapper.Map<List<User>>(userEntities);
            }
        }
        public async Task<User> CreateAsync(User car, CancellationToken cancellationToken = default)
        {
            await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var userEntity = _mapper.Map<UserEntity>(car);
                var result = context.Users.Add(userEntity);
                await context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<User>(result.Entity);
            }
        }
        public async Task<User> UpdateAsync(User car, CancellationToken cancellationToken = default)
        {
            await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var userToUpdateEntity = _mapper.Map<UserEntity>(car);
                var userEntity = await context.Users
                    .AsTracking()
                    .Include(u => u.Cars)
                    .FirstOrDefaultAsync(u => u.Id == userToUpdateEntity.Id, cancellationToken);

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
                await context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<User>(result.Entity);
            }
        }
        public async Task<User> DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            await using(var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken))
            {
                var userEntity = await context.Users
                    .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
                var result = context.Users.Remove(userEntity);
                await context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<User>(result.Entity);
            }
        }
    }
}
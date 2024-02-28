using E_CarShop.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using E_CarShop.Core.Models;
using AutoMapper;

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
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Id == id);
                return _mapper.Map<User>(userEntity);
            }
        }

        public async Task<List<User>> GetUsersAsync(int pageNumber = 1)
        {
            using(var context = _dbContextFactory.CreateDbContext())
            {
                var userEntities = await context.Users.
                    AsNoTracking().
                    ToListAsync();
                return _mapper.Map<List<User>>(userEntities);
            }
        }
        public Task<User> CreateAsync(User car)
        {
            throw new NotImplementedException();
        }
        public Task<User> UpdateAsync(User car)
        {
            throw new NotImplementedException();
        }
        public Task<User> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

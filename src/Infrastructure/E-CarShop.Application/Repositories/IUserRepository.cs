using E_CarShop.Core.Models;

namespace E_CarShop.Application.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetByIdAsync(int id);
        public Task<List<User>> GetUsersAsync(int pageNumber = 1);
        public Task<User> CreateAsync(User car);
        public Task<User> UpdateAsync(User car);
        public Task<User> DeleteByIdAsync(int id);
    }
}
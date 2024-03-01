using E_CarShop.Core.Models;

namespace E_CarShop.Application.Repositories
{
    public interface IUsersRepository
    {
        public Task<User> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task<List<User>> GetUsersAsync(int pageNumber, CancellationToken cancellationToken);
        public Task<User> CreateAsync(User car, CancellationToken cancellationToken);
        public Task<User> UpdateAsync(User car, CancellationToken cancellationToken);
        public Task<User> DeleteByIdAsync(int id, CancellationToken cancellationToken);
    }
}
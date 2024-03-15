using E_CarShop.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using E_CarShop.Core.Models;
using AutoMapper;

namespace E_CarShop.DataBase.Repositories
{
    public class BrandRepository(
        IMapper mapper,
        IDbContextFactory<MainContext> dbContextFactory
        ) : IBrandRepository
    {
        private readonly IMapper _mapper = mapper;
        private readonly IDbContextFactory<MainContext> _dbContextFactory = dbContextFactory;
        public async Task<Brand> GetBrandById(int id, CancellationToken cancellationToken = default)
        {
            await using (var context = _dbContextFactory.CreateDbContext())
            {
                var brandEntity = await context.Brands
                    .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

                var brand = _mapper.Map<Brand>(brandEntity);
                return brand;
            }
        }
    }
}

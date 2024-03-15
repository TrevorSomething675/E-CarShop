using E_CarShop.Core.ResponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetCarsQuery
{
    public class GetCarsQuery(int userId) : IRequest<Result<List<CarResponse>>>
    {
        public int UserId { get; } = userId;
    }
}
using E_CarShop.Core.ResponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetCarByIdQuery
{
    public class GetCarByIdQuery(int id, int userId) : IRequest<Result<CarResponse>>
    {
        public int Id { get; } = id;
        public int UserId { get; } = userId;
    }
}
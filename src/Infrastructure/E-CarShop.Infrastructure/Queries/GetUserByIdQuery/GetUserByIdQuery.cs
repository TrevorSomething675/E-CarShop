using E_CarShop.Core.ResponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery(int id) : IRequest<Result<UserResponse>>
    {
        public int Id { get; } = id;
    }
}
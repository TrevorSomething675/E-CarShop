using E_CarShop.Core.ReponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery(int id) : IRequest<Result<UserResponse>>
    {
        public int Id { get; } = id;
    }
}
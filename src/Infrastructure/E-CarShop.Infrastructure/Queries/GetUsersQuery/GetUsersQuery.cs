using E_CarShop.Core.ReponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetUsersQuery
{
    public class GetUsersQuery(int pageNumber) : IRequest<Result<List<UserResponse>>>
    {
        public int PageNumber { get; } = pageNumber;
    }
}
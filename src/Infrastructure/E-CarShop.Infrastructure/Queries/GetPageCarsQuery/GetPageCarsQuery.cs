using E_CarShop.Core.ReponseModels;
using Ardalis.Result;
using MediatR;

namespace E_CarShop.Infrastructure.Queries.GetPageCarsQuery
{
    public class GetPageCarsQuery(int pageNumber, int userId) : IRequest<Result<List<CarResponse>>>
    {
        public int PageNumber { get; } = pageNumber;
        public int UserId { get; } = userId;
    }
}